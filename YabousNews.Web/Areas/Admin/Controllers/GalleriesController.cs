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
    public class GalleriesController : BaseController
    {
        public GalleriesController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf) : base(userManager, context, mapper, notyf)
        {
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gallery.ToListAsync());
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
            var query = _context.Gallery.Where(x => x.Title== ""&& (!string.IsNullOrEmpty(searchKey) ? x.Title.Contains(searchKey) : true)).OrderByDescending(x => x.Title).ToList();

            int totalCount = query.Count();

            var items = query.Skip(skip).Take(pageSize).ToList();
            //var itemsVM = _mapper.Map<List<NewsCategory>, List<NewsCategoryVM>>(items);
            var itemsVM = new List<Gallery>();

            var data = itemsVM;

            var jsonData = new { draw = draw, recordsFiltered = data.Count(), recordsTotal = query.Count(), data = data };
            return Json(jsonData);
        }

        // GET: Admin/Galleries

        // GET: Admin/Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Admin/Galleries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Details")] Gallery gallery)
        {


            if (ModelState.IsValid)
            {
                var isExists = _context.NewsCategory.Count(x => x.Name == gallery.Title) > 0;
                if (isExists)
                {
                    return new JsonResult(new { isValid = false });
                }
                _context.Add(gallery);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Galleries");
            }
            return View(gallery);

         
        }

        // GET: Admin/Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        // POST: Admin/Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Details")] Gallery gallery)
        {
            if (id != gallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin/Galleries");
            }
            return View(gallery);
        }

        // GET: Admin/Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Gallery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Admin/Galleries/Delete/5
        [HttpPost, ActionName("Delete")] 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Gallery.FindAsync(id);
            _context.Gallery.Remove(gallery);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/Galleries/Index");
        }

        private bool GalleryExists(int id)
        {
            return _context.Gallery.Any(e => e.Id == id);
        }
    }
}
