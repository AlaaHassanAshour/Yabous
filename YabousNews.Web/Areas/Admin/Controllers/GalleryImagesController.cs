using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class GalleryImagesController : BaseController
    { 
        private readonly IWebHostEnvironment _hostingEnvironment; 
        public GalleryImagesController(UserManager<IdentityUser> userManager, IWebHostEnvironment hostingEnvironment, ApplicationDbContext context, IMapper mapper, INotyfService notyf) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }
       
            // GET: Admin/GalleryImages
            public async Task<IActionResult> Index(int? id)
            {

            var galleryImages = await _context.GalleryImages.Include(g => g.Gallery).Where(x=>x.GalleryId==id).ToListAsync();
            return View( galleryImages);
            }

            // GET: Admin/GalleryImages/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var galleryImages = await _context.GalleryImages
                    .Include(g => g.Gallery)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (galleryImages == null)
                {
                    return NotFound();
                }

                return View(galleryImages);
            }

            // GET: Admin/GalleryImages/Create
            public IActionResult Create()
            {

                ViewBag.GalleryId = new SelectList(_context.Gallery, "Id", "Title");
                return View();
            }

            // POST: Admin/GalleryImages/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost] 
            public async Task<IActionResult> Create(GalleryImages galleryImages)
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
                    imegPath =ImegName;
                }
                galleryImages.Image= imegPath;
                _context.Add(galleryImages);
                 await _context.SaveChangesAsync();

                //    return new JsonResult(new { isValid = true, redirectUrl = "/Admin/Galleries" });
                return Redirect("/Admin/Galleries");
            }
            return View(galleryImages);
            }

            // GET: Admin/GalleryImages/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var galleryImages = await _context.GalleryImages.FindAsync(id);
                if (galleryImages == null)
                {
                    return NotFound();
                }
                ViewData["GalleryId"] = new SelectList(_context.Gallery, "Id", "Id", galleryImages.GalleryId);
                return View(galleryImages);
            }
            // POST: Admin/GalleryImages/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost] 
            public async Task<IActionResult> Edit(int id, GalleryImages galleryImages)
            {
                if (id != galleryImages.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(galleryImages);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GalleryImagesExists(galleryImages.Id))
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
                ViewData["GalleryId"] = new SelectList(_context.Gallery, "Id", "Title", galleryImages.GalleryId);
                return View(galleryImages);
            }

        private bool GalleryImagesExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Admin/GalleryImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var galleryImages = await _context.GalleryImages
                    .Include(g => g.Gallery)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (galleryImages == null)
                {
                    return NotFound();
                }

                return View(galleryImages);
            }

            // POST: Admin/GalleryImages/Delete/5
            [HttpPost, ActionName("Delete")] 
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var galleryImages = await _context.GalleryImages.FindAsync(id);
                _context.GalleryImages.Remove(galleryImages);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/Galleries");
            }

      
        }
    } 


