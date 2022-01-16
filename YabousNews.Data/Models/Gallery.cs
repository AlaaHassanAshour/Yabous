using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public List< GalleryImages > GalleryImages { get; set; }
    }
}
