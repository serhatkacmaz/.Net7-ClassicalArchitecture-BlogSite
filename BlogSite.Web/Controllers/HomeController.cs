using BlogSite.Core.DTOs.JWT;
using BlogSite.Web.ApiServices;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthApiService _authApiService;

        public HomeController(ILogger<HomeController> logger, AuthApiService authApiService)
        {
            _logger = logger;
            _authApiService = authApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginClick(LoginDto loginDto)
        {      
            var result = await _authApiService.Login(loginDto);

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

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}