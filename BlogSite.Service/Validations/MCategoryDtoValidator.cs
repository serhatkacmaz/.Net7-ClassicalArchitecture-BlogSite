using BlogSite.Core.DTOs.Master;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Validations
{
    public class MCategoryDtoValidator:AbstractValidator<MCategoryDto>
    {
        public MCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                   .NotNull().WithMessage("{PropertyName} *")
                   .NotEmpty().WithMessage("{PropertyName} *");
        }
    }
}
