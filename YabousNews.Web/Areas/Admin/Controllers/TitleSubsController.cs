using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YabousNews.Data;
using YabousNews.Data.Models;

namespace YabousNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TitleSubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TitleSubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TitleSubs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TitleSub.Include(t => t.NewsCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/TitleSubs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var titleSub = await _context.TitleSub
        //        .Include(t => t.NewsCategory)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (titleSub == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(titleSub);
        //}

        // GET: Admin/TitleSubs/Create
        public IActionResult Create()
        {
            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name");
            return View();
        }

        // POST: Admin/TitleSubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create( TitleSub titleSub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titleSub);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/TitleSubs/index");
            }
            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name", titleSub.NewsCategoryId);
            return View(titleSub);
        }

        // GET: Admin/TitleSubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titleSub = await _context.TitleSub.FindAsync(id);
            if (titleSub == null)
            {
                return NotFound();
            }
            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name", titleSub.NewsCategoryId);
            return View(titleSub);
        }

        //// POST: Admin/TitleSubs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NewsCategoryId")] TitleSub titleSub)
        {
            if (id != titleSub.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titleSub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleSubExists(titleSub.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin/TitleSubs/index");
            }

            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name", titleSub.NewsCategoryId);
            return View(titleSub);
        }

        // GET: Admin/TitleSubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titleSub = await _context.TitleSub
                .Include(t => t.NewsCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titleSub == null)
            {
                return NotFound();
            }

            return View(titleSub);
        }

        // POST: Admin/TitleSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titleSub = await _context.TitleSub.FindAsync(id);
            _context.TitleSub.Remove(titleSub);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/TitleSubs/index");
        }

        private bool TitleSubExists(int id)
        {
            return _context.TitleSub.Any(e => e.Id == id);
        }
    }
}
