using BlogSite.Core.DTOs.Transaction;
using FluentValidation;

namespace BlogSite.Service.Validations
{
    public class TBlogDtoValidator : AbstractValidator<TBlogDto>
    {
        public TBlogDtoValidator()
        {
            RuleFor(x => x.Name)
                   .NotNull().WithMessage("{PropertyName} is required")
                   .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(x => x.Content)
               .NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is not empty");


            RuleFor(x => x.Description)
               .NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is not empty");
        }
    }
}
