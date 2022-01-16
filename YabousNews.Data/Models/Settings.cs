using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public  class Settings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
    }
}