using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;

namespace YabousNews.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AboutController( ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            return View( _context.About.FirstOrDefault(x=>x.Id==id));
        }
    }
}
