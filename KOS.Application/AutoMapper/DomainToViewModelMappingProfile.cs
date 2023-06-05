using System;
using AutoMapper;
using KOS.Application.ViewModels.System;
using KOS.Data.Entities;
using System.Drawing;
using System.Reflection.Metadata;

namespace KOS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //CreateMap<ProductCategory, ProductCategoryViewModel>();
            //CreateMap<Product, ProductViewModel>();
            //CreateMap<Announcement, AnnouncementViewModel>().MaxDepth(2);

            CreateMap<Function, FunctionViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            //CreateMap<Bill, BillViewModel>();
            //CreateMap<BillDetail, BillDetailViewModel>();
            //CreateMap<Color, ColorViewModel>();
            //CreateMap<Size, SizeViewModel>();
            //CreateMap<ProductQuantity, ProductQuantityViewModel>().MaxDepth(2);
            //CreateMap<ProductImage, ProductImageViewModel>().MaxDepth(2);
            //CreateMap<WholePrice, WholePriceViewModel>().MaxDepth(2);

            //CreateMap<Blog, BlogViewModel>().MaxDepth(2);
            //CreateMap<BlogTag, BlogTagViewModel>().MaxDepth(2);
            //CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            //CreateMap<SystemConfig, SystemConfigViewModel>().MaxDepth(2);
            //CreateMap<Footer, FooterViewModel>().MaxDepth(2);

            //CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            //CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            //CreateMap<Page, PageViewModel>().MaxDepth(2);

        }
    }
}
