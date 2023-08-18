using AutoMapper;
using EShoppingAPI.Entity.DTO.Category;
using EShoppingAPI.Entity.Poco;

namespace EShoppingAPI.Apı.Mapping
{
    public class CategoryRequestMapper : Profile
    {
        public CategoryRequestMapper()
        {
            CreateMap<Category, CategoryDTORequest>()
                  .ForMember(dest => dest.Name, opt =>
                  {
                      opt.MapFrom(src => src.Name);
                  }).ReverseMap();


        }


    }
}
