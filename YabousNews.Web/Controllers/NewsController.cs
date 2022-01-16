using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YabousNews.Data;

namespace YabousNews.Web.Controllers
{
    public class NewsController : BaseController
    { 
        public NewsController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper,
          INotyfService notyf) : base(userManager, context, mapper, notyf)
        {
        }

        public IActionResult GetAll()
        {
            var news = _context.News.Include(x => x.NewsCategory).Where(x => x.IsDelete.Equals(false)).OrderByDescending(x => x.Id).ToList();
            return View(news);
        }



        public  IActionResult Index(int id)
        {
            var news = _context.News.Include(x=>x.NewsCategory).Where(x => x.IsDelete.Equals(false)&& x.NewsCategory.Id==id).OrderByDescending(x => x.Id).ToList();
            return View(news);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.Include(x => x.NewsCategory).Where(x => x.IsDelete.Equals(false))
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news== null)
            {
                return NotFound();
            }

            return View(news);
        }

       
        
    }
}