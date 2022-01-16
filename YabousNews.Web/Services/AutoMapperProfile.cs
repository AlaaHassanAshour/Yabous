using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YabousNews.Data.Models;

namespace YabousNews.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<News, NewsVM>();
            CreateMap<CreateNewsDTO, News>();
            CreateMap<EditNewsDTO, News>().ReverseMap();

            CreateMap<NewsCategory, NewsCategoryVM>();
            CreateMap<CreateNewsCategoryDTO, NewsCategory>();
            CreateMap<EditNewsCategoryDTO, NewsCategory>().ReverseMap();
            
            CreateMap<Attachment, AttachmentVM>();
            CreateMap<CreateAttachmentDTO, Attachment>();
            CreateMap<EditAttachmentDTO, Attachment>().ReverseMap();  
            
            CreateMap<About, AboutVM>();
            CreateMap<CreateAboutDTO, About>();
            CreateMap<EditAboutDTO, About>().ReverseMap();
            
            CreateMap<Contact, ContactVM>();
            CreateMap<CreateContactDTO, Contact>();
            CreateMap<EditContactDTO, Contact>().ReverseMap();
            
            CreateMap<Gallery, GalleryVM>();
            CreateMap<CreateGalleryDTO, Gallery>();
            CreateMap<EditGalleryDTO, Gallery>().ReverseMap(); 
            
            CreateMap<GalleryImages, GalleryImagesVM>();
            CreateMap<CreateGalleryImagesDTO, GalleryImages>();
            CreateMap<EditGalleryImagesDTO, GalleryImages>().ReverseMap(); 
            
            CreateMap<Settings, SettingsVM>();
            CreateMap<CreateSettingsDTO, Settings>();
            CreateMap<EditSettingsDTO, Settings>().ReverseMap();

        }
    }
}
