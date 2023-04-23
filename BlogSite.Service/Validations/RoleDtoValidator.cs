using BlogSite.Core.DTOs.UserBase;
using FluentValidation;

namespace BlogSite.Service.Validations
{
    public class RoleDtoValidator : AbstractValidator<RoleDto>
    {
        public RoleDtoValidator()
        {
            //RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater 0");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} *")
                .NotEmpty().WithMessage("{PropertyName} *");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("{PropertyName} *")
                .NotEmpty().WithMessage("{PropertyName} *");
        }
    }
}
