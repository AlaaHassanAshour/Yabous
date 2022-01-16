using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YabousNews.Data;

namespace YabousNews.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly INotyfService _notyf;
        public BaseController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IMapper mapper, INotyfService notyf)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _notyf = notyf;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var settings = _context.Settings.Find(1);
            ViewBag.Logo = !string.IsNullOrEmpty(settings.Logo) ? "/media/images/logo2.png" : "~/Images/" + settings.Logo;
            ViewBag.Title = settings.Title;
            ViewBag.Mobile = settings.MobileNo;
            ViewBag.Email = settings.Email;

        }
    }
}
