using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class News : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Details { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public int NewsCategoryId { get; set; }
        public NewsCategory NewsCategory { get; set; }
    }
}
