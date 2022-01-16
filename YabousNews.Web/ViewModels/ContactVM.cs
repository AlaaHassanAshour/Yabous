using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class ContactVM : BaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "وسيلة التواصل")]
        public string SocialMedia{ get; set; }
        [Display(Name = "الرابط")]
        public string Link { get; set; }
        
    }
}
