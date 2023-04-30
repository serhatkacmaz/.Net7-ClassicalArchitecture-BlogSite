using BlogSite.Common.DTOs.Transaction;
using FluentValidation;

namespace BlogSite.Service.Validations
{
    public class TBlogDtoValidator : AbstractValidator<TBlogDto>
    {
        public TBlogDtoValidator()
        {
            RuleFor(x => x.Category_ID).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} *");

            RuleFor(x => x.Name)
                   .NotNull().WithMessage("{PropertyName} *")
                   .NotEmpty().WithMessage("{PropertyName} *");

            RuleFor(x => x.Content)
               .NotNull().WithMessage("{PropertyName} *")
               .NotEmpty().WithMessage("{PropertyName} *");


            RuleFor(x => x.Description)
               .NotNull().WithMessage("{PropertyName} *")
               .NotEmpty().WithMessage("{PropertyName} *");
        }
    }
}
