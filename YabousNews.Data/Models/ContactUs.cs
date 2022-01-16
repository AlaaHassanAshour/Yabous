using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
  public  class ContactUs
    {
        public int Id{ get; set; }
        public string  FName{ get; set; }
        public string  LName{ get; set; }
        public string  Email{ get; set; }
        public string  Comment{ get; set; }
        public string  Phonenamber{ get; set; }

    }
}
