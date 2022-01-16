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
    public class CreateAboutDTO
    { 
        [Display(Name ="عنوان الصفحة")]
        public string Title { get; set; }

        [Display(Name = "تفاصيل الصفحة")]
        public string Description { get; set; }

        public int? TitleSubId { get; set; }

        public int TitleSub { get; set; }


    }
}
