﻿using AutoMapper;
using EShoppingAPI.Entity.DTO.Product;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Apı.Mapping
{
    public class ProductRequestMapper : Profile
    {
        public ProductRequestMapper()
        {
            CreateMap<Product, ProductDTORequest>()
                  .ForMember(dest => dest.Name, opt =>
                  {
                      opt.MapFrom(src => src.Name);
                  }).ForMember(dest => dest.Description, opt =>
                  {
                      opt.MapFrom(src => src.Description);
                  }).ForMember(dest => dest.CategoryID, opt =>
                  {
                      opt.MapFrom(src => src.CategoryID);
                  }).ForMember(dest => dest.FeaturedImage, opt =>
                  {
                      opt.MapFrom(src => src.FeaturedImage);
                  })
                  .ForMember(dest => dest.Guid, opt =>
                  {
                      opt.MapFrom(src => src.GUID);
                  })
                  .ForMember(dest => dest.UnitPrice, opt =>
                  {
                      opt.MapFrom(src => src.UnitPrice);
                  }).ReverseMap();


        }
    }
}
