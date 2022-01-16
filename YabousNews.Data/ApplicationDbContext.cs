using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YabousNews.Data.Models;

namespace YabousNews.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<About> About { get; set; }
        public DbSet<CatAttatcment> CatAttatcment { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GalleryImages> GalleryImages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategory { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<CategoryAttatcmant> CategoryAttatcmant { get; set; }
        public DbSet<TitleSub> TitleSub { get; set; }
    }
}
