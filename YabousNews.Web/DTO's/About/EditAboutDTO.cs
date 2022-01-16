using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews
{
    public class EditAboutDTO
    {
        public int Id { get; set; } 
        [Display(Name ="عنوان الصفحة")]
        public string Title { get; set; }
        [Display(Name = "تفاصيل الصفحة")]
        public string Description { get; set; }
        public enum SubMenu { Alquds, AboutThis, News, Studies, Articles, Conferences }


    }
}
