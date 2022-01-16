using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;
using YabousNews.Data.Models;

namespace YabousNews.Web.Controllers
{
    public class GalleryImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleryImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GalleryImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GalleryImages.Include(g => g.Gallery);
            return View(await applicationDbContext.OrderByDescending(x => x.Id).ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImages = await _context.GalleryImages.Include(x => x.Gallery)
                .Where(m => m.GalleryId == id).OrderByDescending(x=>x.Id).ToListAsync();
            if (galleryImages == null)
            {
                return NotFound();
            }

            return View(galleryImages);
        }
        }
}
