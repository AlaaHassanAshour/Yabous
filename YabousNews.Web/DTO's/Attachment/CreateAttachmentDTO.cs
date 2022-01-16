using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews
{
    public class CreateAttachmentDTO 
    {
        [Display(Name = "عنوان المرفق")]
        public string Title { get; set; }
        [Display(Name = "المرفق")]
        public IFormFile File { get; set; }
        public string Image{ get; set; }
        public int CategoryAttatcmantId { get; set; }

    }
}
