using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       public int? TitleSubId { get; set; }
        public TitleSub TitleSub { get; set; }
    }
}
