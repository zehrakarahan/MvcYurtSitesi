using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;

namespace YurtYesilKaya.Bll.ValidationRules.FluentValidation
{
    public class KullaniciValidation : AbstractValidator<Kullanici>
    {
        public KullaniciValidation()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("KullaniciId Bos gecilemez!");
            RuleFor(p => p.AdiSoyadi).NotEmpty().WithMessage("Adi Bos gecilemez!");
            
            RuleFor(p => p.KullaniciAdi).NotEmpty().WithMessage("Kullanici Adi Bos gecilemez!");
            RuleFor(p => p.Parola)
          .NotEmpty().WithMessage("Parola alanı boş geçilemez!")
          .Must(IsPasswordValid).WithMessage("Parolanız en az bes karakter, en az bir harf ve bir sayı içermelidir!");

        }

        private bool IsPasswordValid(string arg)
        {
            Regex regEx = new Regex("^[a-zA-Z0-5]*$");
            return regEx.IsMatch(arg);

        }


    }
}
