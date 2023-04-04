using BlogSite.Core.DTOs;
using BlogSite.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogSite.API.Middlewares
{
    public static class UseBlogSiteExceptionHandler
    {
        public static void UseBlogSiteException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var excepitonFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = excepitonFeature.Error switch
                    {
                        ClientSideException => StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    context.Response.StatusCode = statusCode;
                    
                    var response = BlogSiteResponseDto<NoContentDto>.Fail(statusCode, excepitonFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }

    }
}
