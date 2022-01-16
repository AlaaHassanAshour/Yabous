using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YabousNews.Data.Models
{
    public class Contact :BaseEntity
    {
        public int Id { get; set; }
        public string SocialMedia{ get; set; }
        public string Link { get; set; }
    }
}