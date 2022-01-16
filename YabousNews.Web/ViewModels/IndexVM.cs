using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YabousNews.Data.Models;

namespace YabousNews.Web.ViewModels
{
    public class IndexVM
    {
        public List< NewsCategory> NewsCategory { get; set; }
        public List<News> News { get; set; }
        public List <Videos> Videos { get; set; }
        public List<GalleryImages> GalleryImages { get; set; }
        public List<Attachment> Attachment { get; set; }
        public List<Contact> Contact { get; set; }
        public List<Ads> Ads{ get; set; }

      
    }
}
