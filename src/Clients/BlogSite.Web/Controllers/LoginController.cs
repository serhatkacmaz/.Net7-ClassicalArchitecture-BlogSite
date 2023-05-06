using BlogSite.Common.DTOs.JWT;
using BlogSite.Common.DTOs.UserBase;
using BlogSite.Web.ApiServices;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BlogSite.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthApiService _authApiService;
        private readonly UserApiService _userApiService;
        private readonly UserRoleApiService _userRoleApiService;
        private readonly IWebHostEnvironment _environment;
        public LoginController(AuthApiService authApiService, UserApiService userApiService, UserRoleApiService userRoleApiService, IWebHostEnvironment environment)
        {
            _authApiService = authApiService;
            _userApiService = userApiService;
            _userRoleApiService = userRoleApiService;
            _environment = environment;
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
            var split = userDto.UserName.Split(' ');
            var name = split[0][0] + split[1];

            userDto.IsActive = true;
            userDto.Name = name;

            var imagePath = _environment.WebRootPath + "\\img\\avatar.png";
            userDto.Image = System.IO.File.ReadAllBytes(imagePath);

            var result = await _userApiService.SaveAsync(userDto);

            await _userRoleApiService.SaveAsync(new UserRoleDto { IsActive = true, Role_ID = 2, User_ID = result.Data.Id });
            return RedirectToAction("Index", "Home");
        }
    }
}
