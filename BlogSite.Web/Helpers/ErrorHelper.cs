using BlogSite.Core.DTOs;
using BlogSite.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Helpers
{
    public static class ErrorHelper
    {
        public static void ResponseHandler<T>(BlogSiteResponseDto<T> responseDto, ControllerContext controllerContext) where T : class
        {
            if (responseDto.Errors != null && responseDto.Errors.Count > 0)
            {
                foreach (var item in responseDto.Errors)
                {
                    var splitResult = item.Split(' ', 2);

                    var propertyName = splitResult[0];
                    var errorMesage = splitResult[1];
                    controllerContext.ModelState.AddModelError(propertyName, errorMesage);
                }

                throw new ValidateException("Validate error.");
            }
        }
    }

}
