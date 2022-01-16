using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now; 
        }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
    }
}
