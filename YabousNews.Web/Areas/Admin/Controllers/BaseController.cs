using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YabousNews.Data;

namespace YabousNews.Web.Areas.Admin.Controllers
{
    [Authorize]
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
    }
}
