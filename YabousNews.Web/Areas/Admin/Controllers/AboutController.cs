using System;
using System.Collections.Generic;
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

namespace YabousNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController  : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public AboutController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper,
            INotyfService notyf, IHostingEnvironment hostingEnvironment) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }
               // GET: Admin/About
        public async Task<IActionResult> Index()
        {
            return View(await _context.About.Include(x=>x.TitleSub).OrderByDescending(x=>x.Id).ToListAsync());
        } 
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["SubTitleList"] = new SelectList(_context.TitleSub.OrderBy(x => x.Id), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about)
        {
            if (ModelState.IsValid)
            {
            //    var aboutDB = _mapper.Map<CreateAboutDTO, About>(about);
                _context.About.Add(about);
                await _context.SaveChangesAsync();
                _notyf.Success("تمت عملية الإضافة بنجاح");
                return  Redirect("/Admin/About");
            }
            ViewData["SubTitleList"] = new SelectList(_context.TitleSub.OrderBy(x => x.Id), "Id", "Name",about.TitleSub);

            return View(about);
        }
    
        // GET: Admin/About/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.About.FindAsync(id);
            var model = _mapper.Map<About, EditAboutDTO>(about);

            if (about == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Admin/About/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public async Task<IActionResult> Edit(int id,EditAboutDTO about)
        {
            if (id != about.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var aboutDB = _context.About.Find(id);
                    aboutDB.Title = about.Title;
                    aboutDB.Description = about.Description;
                    _context.Update(aboutDB);
                    await _context.SaveChangesAsync();
                    _notyf.Success("تمت عملية التعديل بنجاح");
                    return Redirect("/Admin/About/Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin/About/Index");
            }
            return View(about);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.About
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }
            _context.About.Remove(about);
            _context.SaveChanges();

            _notyf.Success("تمت عملية الحذف بنجاح");
            return Redirect (" /Admin/About");

        }

        private bool AboutExists(int id)
        {
            return _context.About.Any(e => e.Id == id);
        }
    }
}
