﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews
{
    public  class CreateSettingsDTO
    { 
        [Display(Name = "عنوان الموقع")]
        public string Title { get; set; }
        [Display(Name = "الشعار")]
        public IFormFile Logo { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string MobileNo { get; set; }
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
    }
}
