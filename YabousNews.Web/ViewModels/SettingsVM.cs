using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public  class SettingsVM
    {
        public int Id { get; set; }
        [Display(Name = "عنوان الموقع")]
        public string Title { get; set; }
        [Display(Name = "الشعار")]
        public string Logo { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string MobileNo { get; set; }
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
    }
}
