using BlogSite.Core.DTOs.JWT;
using BlogSite.Web.ApiServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BlogSite.Core.DTOs.UserBase;

namespace BlogSite.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthApiService _authApiService;
        private readonly UserApiService _userApiService;

        public LoginController(AuthApiService authApiService, UserApiService userApiService)
        {
            _authApiService = authApiService;
            _userApiService = userApiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginClick(LoginDto loginDto)
        {
            var result = await _authApiService.CreateToken(loginDto);

            if (result.Errors == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(result.Data.AccessToken);
                var claimsIdentity = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = result.Data.RefreshTokenExpiration.AddSeconds(10)
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

                Response.Cookies.Append("X-Access-Token", result.Data.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = result.Data.AccessTokenExpiration
                });
                Response.Cookies.Append("Refresh-Token", result.Data.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = result.Data.RefreshTokenExpiration
                });

            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            userDto.User_ID = 1; //TODO:

            var result = await _userApiService.SaveAsync(userDto);

            return RedirectToAction("Index", "Home");
        }
    }
}
