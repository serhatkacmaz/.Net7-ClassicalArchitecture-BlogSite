using BlogSite.Core.DTOs.UserBase;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
