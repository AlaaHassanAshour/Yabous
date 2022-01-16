using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews
{
    public class EditAttachmentDTO 
    {
        public int Id { get; set; }
        [Display(Name = "عنوان المرفق")]
        public string Title { get; set; }
        [Display(Name = "المرفق")]
        public string File { get; set; }
    }
}
