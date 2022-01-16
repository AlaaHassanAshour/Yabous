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
using YabousNews.Helper;
using YabousNews.Web.Areas.Admin.Controllers;

namespace YabousNews.Controllers
{
    [Area("Admin")]
    public class NewsCategoryController : BaseController
    { 
        public NewsCategoryController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf) :base(userManager,context,mapper,notyf)
        { 
        }

        // GET: Admin/NewsCategory
        public async Task<IActionResult> Index()
        {
            return View();
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
            var query = _context.NewsCategory.Where(x => x.IsDelete == false && (!string.IsNullOrEmpty(searchKey)?x.Name.Contains(searchKey):true)).OrderByDescending(x => x.CreatedAt).ToList();

            int totalCount = query.Count();

            var items = query.Skip(skip).Take(pageSize).ToList();
            var itemsVM = _mapper.Map<List<NewsCategory>, List<NewsCategoryVM>>(items);

            var data = itemsVM;
               
            var jsonData = new { draw = draw, recordsFiltered = data.Count(), recordsTotal = query.Count(), data = data };
            return Json(jsonData);
        }
        
        // GET: Admin/NewsCategory/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public async Task<IActionResult> Create(CreateNewsCategoryDTO newsCategory)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CreateNewsCategoryDTO, NewsCategory>(newsCategory);
                var isExists = _context.NewsCategory.Count(x => x.Name == newsCategory.Name) > 0;
                if (isExists)
                {
                    _notyf.Error("تمت إضافة هذا النوع مسبقا");
                    return new JsonResult(new { isValid = false }); 
                }
                 category.CreatedBy = ViewBag.UserID;
                _context.Add(category);
                await _context.SaveChangesAsync();
                _notyf.Success("تمت عملية الإضافة بنجاح");
                return new JsonResult(new { isValid = true, redirectUrl = "/Admin/NewsCategory" }); 
            }
            return View(newsCategory);
        }
       
        // GET: Admin/NewsCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var newsCategory = await _context.NewsCategory.FindAsync(id);
            var model = _mapper.Map<NewsCategory, EditNewsCategoryDTO>(newsCategory); 

            if (newsCategory == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Admin/NewsCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public async Task<IActionResult> Edit(int id,EditNewsCategoryDTO newsCategory)
        {
            if (id != newsCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { 
                        var isExists = _context.NewsCategory.Count(x => x.Name == newsCategory.Name && x.Id != newsCategory.Id) > 0;
                        if (isExists)
                        {
                        _notyf.Error("تمت إضافة هذا النوع مسبقا");
                        return new JsonResult(new { isValid = false}); 
                    }
                    var newsCategoryDB = _context.NewsCategory.Find(id);
                        newsCategoryDB.Name = newsCategory.Name;
                        newsCategoryDB.UpdatedAt = DateTime.Now;
                        newsCategoryDB.UpdatedBy = ViewBag.UserID;
                        _context.Update(newsCategoryDB);
                        await _context.SaveChangesAsync();
                    _notyf.Success("تمت عملية التعديل بنجاح");
                    return new JsonResult(new { isValid = true, redirectUrl = "/Admin/NewsCategory" });

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsCategoryExists(newsCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(newsCategory);
        }

        // GET: Admin/NewsCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.NewsCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDelete = true;
            _context.SaveChanges(); 
            _notyf.Success("تمت عملية الحذف بنجاح");
            return new JsonResult(new { isValid = true, actionType= "redirect",redirectUrl = " /Admin/NewsCategory" });

        }
        private bool NewsCategoryExists(int id)
        {
            return _context.NewsCategory.Any(e => e.Id == id);
        }
    }
}