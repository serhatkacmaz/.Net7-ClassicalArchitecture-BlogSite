using BlogSite.Common.DTOs.Master;
using FluentValidation;

namespace BlogSite.Service.Validations
{
    public class MCategoryDtoValidator : AbstractValidator<MCategoryDto>
    {
        public MCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                   .NotNull().WithMessage("{PropertyName} *")
                   .NotEmpty().WithMessage("{PropertyName} *");
        }
    }
}
