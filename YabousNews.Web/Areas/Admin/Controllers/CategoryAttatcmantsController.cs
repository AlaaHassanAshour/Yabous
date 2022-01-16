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
    public class CategoryAttatcmantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryAttatcmantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CategoryAttatcmants
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryAttatcmant.OrderByDescending(x => x.Id).ToListAsync());
        }

        // GET: Admin/CategoryAttatcmants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryAttatcmant = await _context.CategoryAttatcmant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryAttatcmant == null)
            {
                return NotFound();
            }

            return View(categoryAttatcmant);
        }

        // GET: Admin/CategoryAttatcmants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryAttatcmants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryAttatcmant categoryAttatcmant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryAttatcmant);
                await _context.SaveChangesAsync();
                return Redirect("/Admin/CategoryAttatcmants/index");
            }
            return View(categoryAttatcmant);
        }

        // GET: Admin/CategoryAttatcmants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryAttatcmant = await _context.CategoryAttatcmant.FindAsync(id);
            if (categoryAttatcmant == null)
            {
                return NotFound();
            }
            return View(categoryAttatcmant);
        }

        // POST: Admin/CategoryAttatcmants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryAttatcmant categoryAttatcmant)
        {
            if (id != categoryAttatcmant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryAttatcmant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryAttatcmantExists(categoryAttatcmant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Admin/CategoryAttatcmants/index");
            }
            return View(categoryAttatcmant);
        }

        // GET: Admin/CategoryAttatcmants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryAttatcmant = await _context.CategoryAttatcmant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryAttatcmant == null)
            {
                return NotFound();
            }

            return View(categoryAttatcmant);
        }

        // POST: Admin/CategoryAttatcmants/Delete/5
        [HttpPost, ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryAttatcmant = await _context.CategoryAttatcmant.FindAsync(id);
            _context.CategoryAttatcmant.Remove(categoryAttatcmant);
            await _context.SaveChangesAsync();
            return Redirect("/Admin/CategoryAttatcmants/index");
        }

        private bool CategoryAttatcmantExists(int id)
        {
            return _context.CategoryAttatcmant.Any(e => e.Id == id);
        }
    }
}
