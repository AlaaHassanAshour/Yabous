using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews
{
    public class EditGalleryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="يرجى تعبئة عنوان الألبوم")]
        [Display(Name = "عنوان الألبوم")]
        public string Title { get; set; }
        [Display(Name = "تفاصيل الألبوم")]
        public string Details { get; set; }
    }
}
