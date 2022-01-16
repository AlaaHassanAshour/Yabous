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
using YabousNews.Data;
using YabousNews.Data.Models;
using YabousNews.Helper;
using YabousNews.Web.Areas.Admin.Controllers;

namespace YabousNews.Controllers
{
    [Area("Admin")]
    public class SettingsController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public SettingsController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper,
            INotyfService notyf,IHostingEnvironment hostingEnvironment) : base(userManager, context, mapper, notyf)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Settings
        public async Task<IActionResult> Index()
        {
            return View();
        }   

        // GET: Settings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings.FindAsync(id);
             var model = _mapper.Map<Settings, EditSettingsDTO>(settings);

            if (settings == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public async Task<IActionResult> Edit(int id, EditSettingsDTO settings,IFormFile Logo)
        {
            if (id != settings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {  
                    var settingDB = _context.Settings.Find(id);
                    settingDB.Title = settings.Title;
                    settingDB.MobileNo = settings.MobileNo;
                    settingDB.Email = settings.Email;
                    if(Logo != null && Logo.Length > 0)
                    {
                        String fileName = null;
                        string extension = Path.GetExtension(Logo.FileName);
                        string type = Logo.ContentType;

                        if (type.Contains("image"))
                        {
                            var saveImg = ImageHelper.SaveImage(Logo, _hostingEnvironment,"Images");
                            fileName = saveImg.Result;
                        }
                        settingDB.Logo = fileName;
                    }
                    _context.Update(settingDB);
                    await _context.SaveChangesAsync();
                    _notyf.Success("تمت عملية التعديل بنجاح");
                    return Redirect("/Admin/Settings/Edit/1");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingsExists(settings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                } 
            }
            return View(settings);
        }

        
        private bool SettingsExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
