using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;

namespace YabousNews.Web.Controllers
{
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideosController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.OrderByDescending(x => x.Id).ToListAsync());
        }
    }
}
