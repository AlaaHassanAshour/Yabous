using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YabousNews
{
    public class EditNewsCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="يرجى تعبئة النوع")]
        [Display(Name = "النوع")]
        public string Name { get; set; }
        
    }
}
