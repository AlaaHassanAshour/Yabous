using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YabousNews.Data.Models;

namespace YabousNews
{
    public class CreateGalleryImagesDTO
    { 
        [Display(Name = "إضافة صور الألبوم")]
        public IFormFile Image { get; set; }
        [Display(Name = "تابع لألبوم")]
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}
