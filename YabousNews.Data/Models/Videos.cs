using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
   public class Videos
    {
        public int Id{ get; set; }
        [Required]
        public string Url{ get; set; }
        [Required]
        public string Name{ get; set; }
        public string Image { get; set; }
    }
}
