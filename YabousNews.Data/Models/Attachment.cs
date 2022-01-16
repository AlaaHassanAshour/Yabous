using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class Attachment : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string Image { get; set; }
        public int CategoryAttatcmantId { get; set; }
        public CategoryAttatcmant CategoryAttatcmant { get; set; }
    }
}
