using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;
using YabousNews.Data.Models;

namespace YabousNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdsController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdsController(UserManager<IdentityUser> userManager, IWebHostEnvironment hostingEnvironment,
            ApplicationDbContext context, IMapper mapper, INotyfService notyf) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Admin/Ads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ads.ToListAsync());
        }

        // GET: Admin/Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ads = await _context.Ads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ads == null)
            {
                return NotFound();
            }

            return View(ads);
        }

        // GET: Admin/Ads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,name,url,imeg,UpDown")] Ads ads)
        {
            if (ModelState.IsValid)
            {
                string imegPath = @"default.jpg";
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string ImegName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "Images", ImegName), FileMode.Create);
                    files[0].CopyTo(fileStream);
                    imegPath = ImegName;
                }
                ads.imeg= imegPath;
                _context.Add(ads);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Ads/index");
            }
            return View(ads);
        }

        // GET: Admin/Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ads = await _context.Ads.FindAsync(id);
            if (ads == null)
            {
                return NotFound();
            }
            return View(ads);
        }

        // POST: Admin/Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,url,imeg")] Ads ads)
        {
            if (id != ads.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdsExists(ads.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin/Ads");
            }
            return View(ads);
        }

        // GET: Admin/Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ads = await _context.Ads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ads == null)
            {
                return NotFound();
            }

            return View(ads);
        }

        // POST: Admin/Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ads = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ads);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/Ads");
        }

        private bool AdsExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
