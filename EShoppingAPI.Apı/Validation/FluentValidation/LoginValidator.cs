using EShoppingAPI.Entity.DTO.Login;
using FluentValidation;

namespace EShoppingAPI.Apı.Validation.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(q => q.KullanıcıAdı).NotEmpty().WithMessage(" Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Şifre).NotEmpty().WithMessage(" Şifre Boş Olamaz");

        }
    }
}
