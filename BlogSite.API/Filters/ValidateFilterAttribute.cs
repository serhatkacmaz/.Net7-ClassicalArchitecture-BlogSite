using BlogSite.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogSite.API.Filters
{
    /// <summary>
    /// FluentValidation custom bir excepiton fırlattığı zaman yakalayıp, kendi custom response modelimize dönüştürme.
    /// </summary>
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(BlogSiteResponseDto<NoContentDto>.Fail(StatusCodes.Status400BadRequest, errors));
            }
        }

    }
}
