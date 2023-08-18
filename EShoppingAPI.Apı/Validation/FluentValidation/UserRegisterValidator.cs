using EShoppingAPI.Entity.DTO.User;
using FluentValidation;

namespace EShoppingAPI.Apı.Validation.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserDTORequest>
    {

        public UserRegisterValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage(" Ad Boş Olamaz");
            RuleFor(q => q.LastName).NotEmpty().WithMessage(" Soyad Boş Olamaz");
            RuleFor(q => q.UserName).NotEmpty().WithMessage(" Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage(" Şifre Boş Olamaz");
            RuleFor(q => q.Email).NotEmpty().WithMessage(" Email Boş Olamaz");
            RuleFor(q => q.PhoneNumber).NotEmpty().WithMessage(" Telefon Numarası Boş Olamaz");
            RuleFor(q => q.Adress).NotEmpty().WithMessage(" Adres Boş Olamaz");






        }
    }
}
