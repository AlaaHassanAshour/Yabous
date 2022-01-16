using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using YabousNews.Data;
using YabousNews.Data.Models;
using YabousNews.Helper;
using YabousNews.Web.Areas.Admin.Controllers;

namespace YabousNews.Controllers
{

    [Area("Admin")]
    public class NewsController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public NewsController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf,IHostingEnvironment hostingEnvironment) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: News
        public async Task<IActionResult> Index()
        {
            ViewData["CategoryList"] = new SelectList(_context.NewsCategory.Where(x=>x.IsDelete.Equals(false)).OrderBy(x=>x.Id), "Id", "Name"); 
            return View();
        }

        public JsonResult IndexAjax(IFormCollection form)
        {
            var draw = form["draw"].FirstOrDefault();
            var start = form["start"].FirstOrDefault();
            var searchKey = form["SearchKey"];
            int.TryParse(form["category"],out int category);
            var length = form["length"].FirstOrDefault();
            var sortColumn = form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = form["order[0][dir]"].FirstOrDefault();
            string title = form["Title"];
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            var query = _context.News.Include(x=>x.NewsCategory)
                .Where(x => x.IsDelete == false && (!string.IsNullOrEmpty(searchKey) ?x.Title.Contains(searchKey) :true))
                .Where(x=> !category.Equals(0)? x.NewsCategoryId.Equals(category):true)
                .OrderByDescending(x => x.CreatedAt).ToList();

            int totalCount = query.Count();

            var items = query.Skip(skip).Take(pageSize).ToList();
            var itemsVM = _mapper.Map<List<News>, List<NewsVM>>(items);
            var data = itemsVM.Select(x => new
            {
                Id = x.Id,
                Image = x.Image,
                Category = x.NewsCategory.Name,
                Title = x.Title,
                CreatedAt = x.CreatedAt,
                Author = x.Author
            });
            var jsonData = new { draw = draw, recordsFiltered = data.Count(), recordsTotal = query.Count(), data = data };

            return Json(jsonData);
        }

        
        // GET: News/Create
        public IActionResult Create()
        {
            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory.Where(x => x.IsDelete.Equals(false)), "Id", "Name");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public async Task<IActionResult> Create(CreateNewsDTO news)
         {
            if (ModelState.IsValid)
            {
                var newsDB = _mapper.Map<CreateNewsDTO, News>(news); 
                ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory.Where(x => x.IsDelete.Equals(false)), "Id", "Name", newsDB.NewsCategoryId);
                newsDB.CreatedBy = ViewBag.UserID;
                string imegPath = @"default.jpg";
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string webRootPath =
                        _hostingEnvironment.WebRootPath;
                    string ImegName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "Images", ImegName), FileMode.Create);
                    files[0].CopyTo(fileStream);
                    imegPath = ImegName;
                }
                newsDB.Image = imegPath;
                _context.Add(newsDB);
                await _context.SaveChangesAsync();
                _notyf.Success("تمت عملية الإضافة بنجاح");
                // return new JsonResult(new { isValid = true, redirectUrl = "/Admin/News/" });
                return Redirect("/Admin/News/");
            }

            return View();
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            var model = _mapper.Map<News, EditNewsDTO>(news);

            if (news == null)
            {
                return NotFound();
            }
            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory.Where(x => x.IsDelete.Equals(false)), "Id", "Name", news.NewsCategoryId);
            return View(model);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public async Task<IActionResult> Edit(int id, EditNewsDTO news,IFormFile Image)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var newsDB = _context.News.Find(id);
                    newsDB.Title = news.Title;
                    newsDB.Details = news.Details;
                    newsDB.NewsCategoryId = news.NewsCategoryId;
                    newsDB.Author = news.Author;
                    if(Image!=null&&Image.Length > 0)
                    {
                        String fileName = null;
                        string extension = Path.GetExtension(Image.FileName);
                        string type = Image.ContentType;

                        if (type.Contains("image"))
                        {
                            var saveImg = ImageHelper.SaveImage(Image, _hostingEnvironment,"Images");
                            fileName = saveImg.Result;
                        }
                        newsDB.Image = fileName;
                    }
                    newsDB.UpdatedAt = DateTime.Now;
                    newsDB.UpdatedBy = ViewBag.UserID;
                    _context.Update(newsDB);
                    await _context.SaveChangesAsync();
                    _notyf.Success("تمت عملية التعديل بنجاح");
                    return Redirect("/Admin/News/");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["NewsCategoryId"] = new SelectList(_context.NewsCategory.Where(x => x.IsDelete.Equals(false)), "Id", "Name", news.NewsCategoryId);
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            news.IsDelete = true;
            _context.SaveChanges();

            _notyf.Success("تمت عملية الحذف بنجاح");
            return new JsonResult(new { isValid = true,actionType="redirect", redirectUrl = "/Admin/News" });
           //   return Redirect("/Admin/News");

        }
        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
