using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.ValidationRules
{
	public class CategoryValidator : AbstractValidator<CategoryDto>
	{
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kateğori adını boş geçemezsiniz");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Kateğori açıklamasını boş geçemezsiniz");
			RuleFor(c => c.Name).NotEmpty().MaximumLength(50).WithMessage("Kateğori adı en fazla 50 karakter olmalıdır");
			RuleFor(c => c.Name).NotEmpty().MinimumLength(2).WithMessage("Kateğori adı en az 2 karakter olmalıdır");
		}
    }
}
