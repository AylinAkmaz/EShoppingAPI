using EShoppingAPI.Entity.DTO.Category;
using FluentValidation;

namespace EShoppingAPI.Apı.Validation.FluentValidation
{
    public class CategoryValidatior : AbstractValidator<CategoryDTORequest>
    {

        public CategoryValidatior()
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
        }
    }
}
