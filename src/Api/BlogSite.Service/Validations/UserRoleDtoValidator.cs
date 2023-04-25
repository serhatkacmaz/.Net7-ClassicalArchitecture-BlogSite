using BlogSite.Common.DTOs.UserBase;
using FluentValidation;

namespace BlogSite.Service.Validations
{
    public class UserRoleDtoValidator : AbstractValidator<UserRoleDto>
    {
        public UserRoleDtoValidator()
        {
            RuleFor(x => x.Role_ID).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} *");
            RuleFor(x => x.User_ID).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} *");
        }
    }
}
