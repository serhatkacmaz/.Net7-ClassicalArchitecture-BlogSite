using BlogSite.API.Filters;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Services;
using BlogSite.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<User, UserDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            return CreateActionResult(await _userService.AddAsync(userDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            return CreateActionResult(await _userService.UpdateAsync(userDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<User, UserDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _userService.RemoveAsync(id));
        }

    }
}
