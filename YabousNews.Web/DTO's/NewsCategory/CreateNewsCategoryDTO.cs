using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YabousNews
{
    public class CreateNewsCategoryDTO
    { 
        [Required(ErrorMessage ="يرجى تعبئة النوع")]
        [Display(Name = "النوع")]
        public string Name { get; set; }
        
    }
}
