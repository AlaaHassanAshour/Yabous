using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;
using YabousNews.Data.Models;

namespace YabousNews.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ContactController : BaseController
    {
        public ContactController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf) : base(userManager, context, mapper, notyf)
        {
        }

        // GET: Admin/Contact
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
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
            var query = _context.Contact.Where(x => x.IsDelete == false && (!string.IsNullOrEmpty(searchKey) ? x.SocialMedia.Contains(searchKey) : true)).OrderByDescending(x => x.CreatedAt).ToList();

            int totalCount = query.Count();

            var items = query.Skip(skip).Take(pageSize).ToList();
            var itemsVM = _mapper.Map<List<Contact>, List<ContactVM>>(items);

            var data = itemsVM;

            var jsonData = new { draw = draw, recordsFiltered = data.Count(), recordsTotal = query.Count(), data = data };
            return Json(jsonData);
        } 
         

        // GET: Admin/Contact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public async Task<IActionResult> Create(CreateContactDTO contact)
        {
            if (ModelState.IsValid)
            {
                var contactDB = _mapper.Map<CreateContactDTO, Contact>(contact);
                var isExists = _context.Contact.Count(x => x.SocialMedia == contactDB.SocialMedia) > 0;
                if (isExists)
                {
                    _notyf.Error("تمت إضافة هذا النوع مسبقا");
                    return new JsonResult(new { isValid = false });
                }
                contactDB.CreatedBy = ViewBag.UserID;
                _context.Add(contactDB);
                 await _context.SaveChangesAsync();
                _notyf.Success("تمت عملية الإضافة بنجاح");
                return new JsonResult(new { isValid = true, redirectUrl = "/Admin/Contact" });
            }
            return View(contact);
        }

        // GET: Admin/Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _context.Contact.FindAsync(id);
            var model = _mapper.Map<Contact, EditContactDTO>(contact);
            if (contact == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Admin/Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public async Task<IActionResult> Edit(int id, EditContactDTO contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var isExists = _context.Contact.Count(x => x.SocialMedia == contact.SocialMedia && x.Id != contact.Id) > 0;
                    if (isExists)
                    {
                        _notyf.Error("تمت إضافة هذا النوع مسبقا");
                        return new JsonResult(new { isValid = false });
                    }
                    var contacDB = _context.Contact.Find(id);
                    contacDB.SocialMedia = contact.SocialMedia;
                    contacDB.Link = contact.Link;
                    contacDB.UpdatedAt = DateTime.Now;
                    contacDB.UpdatedBy = ViewBag.UserID;
                    _context.Update(contacDB);
                    await _context.SaveChangesAsync();
                    _notyf.Success("تمت عملية التعديل بنجاح");
                    return new JsonResult(new { isValid = true, redirectUrl = "/Admin/Contact" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Admin/NewsCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            contact.IsDelete = true;
            _context.SaveChanges();
            _notyf.Success("تمت عملية الحذف بنجاح");
            return new JsonResult(new { isValid = true, redirectUrl = "/Admin/Contact" });
        }
        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}