﻿using AutoMapper;
using EShoppingAPI.Entity.DTO.User;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Apı.Mapping
{
    public class UserResponseMapper:Profile
    {
        public UserResponseMapper()
        {
            CreateMap<User, UserDTOResponse>()
             .ForMember(dest => dest.FirstName, opt =>
             {
                 opt.MapFrom(src => src.FirstName);
             })
          .ForMember(dest => dest.LastName, opt =>
          {
              opt.MapFrom(src => src.LastName);
          })
           .ForMember(dest => dest.UserName, opt =>
           {
               opt.MapFrom(src => src.Username);
           })
            .ForMember(dest => dest.Password, opt =>
            {
                opt.MapFrom(src => src.Password);
            })
            .ForMember(dest => dest.PhoneNumber, opt =>
            {
                opt.MapFrom(src => src.PhoneNumber);
            })
            .ForMember(dest => dest.Email, opt =>
            {
                opt.MapFrom(src => src.Email);
            })
            .ForMember(dest => dest.Adress, opt =>
            {
                opt.MapFrom(src => src.Adress);
            })
             .ForMember(dest => dest.Guid, opt =>
             {
                 opt.MapFrom(src => src.GUID);
             }).ReverseMap();
        }

    }
}
