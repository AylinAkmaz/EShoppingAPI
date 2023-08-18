using AutoMapper;
using EShoppingAPI.Entity.DTO.Category;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Apı.Mapping
{
    public class CategoryResponseMapper : Profile
    {
        public CategoryResponseMapper()
        {
            CreateMap<Category, CategoryDTOResponse>()
                 .ForMember(dest => dest.Name, opt =>
                 {
                     opt.MapFrom(src => src.Name);
                 })
                  .ForMember(dest => dest.GUID, opt =>
                  {
                      opt.MapFrom(src => src.GUID);
                  }).ReverseMap();

        }


    }
}
