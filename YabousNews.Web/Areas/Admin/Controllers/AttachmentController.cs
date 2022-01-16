using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;
using YabousNews.Data.Models;
using YabousNews.Helper;

namespace YabousNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttachmentController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public AttachmentController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf, IHostingEnvironment hostingEnvironment) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: Admin/Attachment
        public async Task<IActionResult> Index()
        {
            ViewData["CategoryAttcmentList"] = new SelectList(_context.CategoryAttatcmant.OrderBy(x => x.Id), "Id", "Name");

            return View(await _context.Attachment.OrderByDescending(x => x.Id).ToListAsync());
        }


        public JsonResult IndexAjax(IFormCollection form)
        {

            var draw = form["draw"].FirstOrDefault();
            var start = form["start"].FirstOrDefault();
            var searchKey = form["SearchKey"];
            var length = form["length"].FirstOrDefault();
            var sortColumn = form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = form["order[0][dir]"].FirstOrDefault();
            string title = form["Title"];
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            var query = _context.Attachment.Where(x => x.IsDelete == false && (!string.IsNullOrEmpty(searchKey) ? x.Title.Contains(searchKey) : true)).OrderByDescending(x => x.CreatedAt).ToList();

            int totalCount = query.Count();

            var items = query.Skip(skip).Take(pageSize).ToList();
            var itemsVM = _mapper.Map<List<Attachment>, List<AttachmentVM>>(items);
            var data = itemsVM;
            var jsonData = new { draw = draw, recordsFiltered = data.Count(), recordsTotal = query.Count(), data = data };
            return Json(jsonData);
        }

        // GET: Admin/Attachment/Create
        public IActionResult Create()
        {
            ViewData["CategoryAttacmentId"] = new SelectList(_context.CategoryAttatcmant, "Id", "Name");

            return View();
        }

        // POST: Admin/Attachment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(CreateAttachmentDTO attachment)
        {
            if (ModelState.IsValid)
            {
                var attach = _mapper.Map<CreateAttachmentDTO, Attachment>(attachment);
                var isExists = _context.Attachment.Count(x => x.Title == attachment.Title) > 0;
                if (attachment.File != null && attachment.File.Length > 0)
                {
                    String fileName = null;
                    var saveImg = ImageHelper.SaveImage(attachment.File, _hostingEnvironment, "Files");
                    fileName = saveImg.Result;
                    attach.File = fileName;
                }

                var files = HttpContext.Request.Form.Files;
                string imegPath = @"pdflog.png";
                if (files.Count > 0)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string ImegName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "Images", ImegName), FileMode.Create);
                    files[0].CopyTo(fileStream);
                    imegPath = ImegName;
                }
                attach.Image = imegPath;
                attach.CreatedBy = ViewBag.UserID;
                _context.Add(attach);
                await _context.SaveChangesAsync();
                _notyf.Success("تمت عملية الإضافة بنجاح");
                return new JsonResult(new { isValid = true, redirectUrl = "/Admin/Attachment" });

                //return  Redirect("/Admin/Attachment/Index"); 
            }
            ViewData["CategoryAttacmentId"] = new SelectList(_context.CategoryAttatcmant, "Id", "Name", attachment.CategoryAttatcmantId);
            return View(attachment);
        }

        // GET: Admin/Attachment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _context.Attachment.FindAsync(id);
            var model = _mapper.Map<Attachment, EditAttachmentDTO>(attachment);
            if (attachment == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Admin/Attachment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Attachment attachment, IFormFile file)
        {
            if (id != attachment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var attach = _context.Attachment.Find(id);
                    var isExists = _context.Attachment.Count(x => x.Title == attachment.Title) > 0;
                    if (file != null && file.Length > 0)
                    {
                        String fileName = null;
                        var saveImg = ImageHelper.SaveImage(file, _hostingEnvironment, "Files");
                        fileName = saveImg.Result;
                        attach.File = fileName;
                    }

                    attach.Title = attachment.Title;
                    attach.UpdatedAt = DateTime.Now;
                    attach.UpdatedBy = ViewBag.UserID;
                    _context.Update(attach);
                    await _context.SaveChangesAsync();
                    _notyf.Success("تمت عملية الإضافة بنجاح");
                    return new JsonResult(new { isValid = true, actionType = "redirect", redirectUrl = "/Admin/Attachment" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentExists(attachment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(attachment);
        }

        // GET: Admin/Attachment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attach = await _context.Attachment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attach == null)
            {
                return NotFound();
            }
            _context.Remove(attach);
            _context.SaveChanges();
            _notyf.Success("تمت عملية الحذف بنجاح");
            return new JsonResult(new { isValid = true, actionType = "redirect", redirectUrl = "/Admin/Attachment" });

        }
        private bool AttachmentExists(int id)
        {
            return _context.Attachment.Any(e => e.Id == id);
        }
    }
}
