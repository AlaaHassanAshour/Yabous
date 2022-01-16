using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class TitleSub
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int NewsCategoryId { get; set; }
        public NewsCategory NewsCategory { get; set; }
    }
}
