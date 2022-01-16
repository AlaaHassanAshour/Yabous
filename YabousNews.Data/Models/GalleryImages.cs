using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class GalleryImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}
