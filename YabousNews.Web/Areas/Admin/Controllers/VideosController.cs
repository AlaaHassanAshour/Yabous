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

namespace YabousNews.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class VideosController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public VideosController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf, IHostingEnvironment hostingEnvironment) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }



        // GET: Admin/Videos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.ToListAsync());
        }
        /*

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
            var query = _context.Videos.Where(x => x.Name== "" && (!string.IsNullOrEmpty(searchKey) ? x.Name.Contains(searchKey) : true)).OrderByDescending(x => x.Name).ToList();

            int totalCount = query.Count();

            var items = query.Skip(skip).Take(pageSize).ToList();
            //var itemsVM = _mapper.Map<List<NewsCategory>, List<NewsCategoryVM>>(items);
            var itemsVM = new List<Videos>();

            var data = itemsVM;

            var jsonData = new { draw = draw, recordsFiltered = data.Count(), recordsTotal = query.Count(), data = data };
            return Json(jsonData);
        }

        */
        // GET: Admin/Videos/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // GET: Admin/Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create( Videos videos)
        {
            if (ModelState.IsValid)
            {
                 string imegPath = @"/Images/youtyublog.png";
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string ImegName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "Images", ImegName), FileMode.Create);
                    files[0].CopyTo(fileStream);
                    imegPath = ImegName;
                }
                videos.Image = imegPath;

                _context.Add(videos);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Videos/");
            }
            return View(videos);
        }

        // GET: Admin/Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos.FindAsync(id);
            if (videos == null)
            {
                return NotFound();
            }
            return View(videos);
        }

        // POST: Admin/Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id,  Videos videos)
        {
            if (id != videos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideosExists(videos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin/Videos/Index");
            }
            return View(videos);
        }

        // GET: Admin/Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // POST: Admin/Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videos = await _context.Videos.FindAsync(id);
            _context.Videos.Remove(videos);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/Videos/Index");
        }

        private bool VideosExists(int id)
        {
            return _context.Videos.Any(e => e.Id == id);
        }
    }
}
