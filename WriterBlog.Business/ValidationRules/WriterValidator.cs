using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.ValidationRules
{
	public class WriterValidator : AbstractValidator<WriterDto>
	{
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar aadı soyadı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");
        }
    }
}
