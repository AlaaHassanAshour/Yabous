using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YabousNews.Data.Models;

namespace YabousNews
{
    public class EditNewsDTO 
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="يرجى تعبئة العنوان")]
        [Display(Name = "العنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "يرجى تعبئة التفاصيل")]
        [Display(Name = "التفاصيل")]
        public string Details { get; set; } 
        [Display(Name = "الصورة الرئيسية")]
        public string Image { get; set; }
        [Display(Name = "اسم الكاتب")]
        public string Author { get; set; }
        [Display(Name = "النوع")]
        public int NewsCategoryId { get; set; }
        public NewsCategory NewsCategory { get; set; }
    }
}
