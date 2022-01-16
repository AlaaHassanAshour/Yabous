using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class Ads
    {
        public int  Id{ get; set; }
        
        public string name{ get; set; }
        public string url{ get; set; }
        public string imeg{ get; set; }
        public EAds UpDown { get; set; }
        public enum EAds { Up , Down}
    }
}
