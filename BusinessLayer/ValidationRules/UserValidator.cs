using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules
{
    public class UserValidator :AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ad kısmı boş geçilemez");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Soyad kısmı boş geçilemez");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");

        }
    }
}
