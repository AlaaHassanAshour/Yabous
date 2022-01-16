using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews
{
    public class EditContactDTO
    {
        public int Id { get; set; }
        [Display(Name = "وسيلة التواصل")]
        public string SocialMedia{ get; set; }
        [Display(Name = "الرابط")]
        public string Link { get; set; }
        
    }
}
