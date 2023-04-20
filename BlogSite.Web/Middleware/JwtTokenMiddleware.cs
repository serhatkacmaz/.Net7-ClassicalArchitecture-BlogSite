using BlogSite.Core.DTOs.JWT;
using BlogSite.Web.ApiServices;
using System.IdentityModel.Tokens.Jwt;

namespace BlogSite.Web.Middleware
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthApiService _authApiService;

        public JwtTokenMiddleware(RequestDelegate next, AuthApiService authApiService)
        {
            _next = next;
            _authApiService = authApiService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var accessToken = context.Request.Cookies["X-Access-Token"];
            var refreshToken = context.Request.Cookies["Refresh-Token"];

            if (context.Request.Path.Value.Contains("Login/") || context.Request.Path.Value.Contains("Home/Index"))
            {
                await _next(context);
                return;
            }

            if (!string.IsNullOrEmpty(accessToken))
            {
                context.Request.Headers.Add("Authorization", $"Bearer {accessToken}");
            }
            else
            {
                if (!string.IsNullOrEmpty(refreshToken))
                {
                    var refreshResult = await _authApiService.CreateTokenByRefreshToken(new RefreshTokenDto() { Token = refreshToken });

                    if (refreshResult.Errors is null)
                    {
                        context.Response.Cookies.Append("X-Access-Token", refreshResult.Data.AccessToken, new CookieOptions
                        {
                            HttpOnly = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = refreshResult.Data.AccessTokenExpiration
                        });

                        context.Response.Cookies.Append("Refresh-Token", refreshResult.Data.RefreshToken, new CookieOptions
                        {
                            HttpOnly = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = refreshResult.Data.RefreshTokenExpiration
                        });
                    }
                }
                else
                {
                    context.User = null;
                    context.Response.Redirect("/Home/Index");
                    return; //INFO returnURl cancel
                }
            }   

            await _next(context);
        }
    }
}