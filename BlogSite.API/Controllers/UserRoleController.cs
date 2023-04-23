using BlogSite.API.Filters;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _userRoleService.GetAllWithIncludeAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<UserRole, UserRoleDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _userRoleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserRoleDto userRoleDto)
        {
            return CreateActionResult(await _userRoleService.AddAsync(userRoleDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserRoleDto userRoleDto)
        {
            return CreateActionResult(await _userRoleService.UpdateAsync(userRoleDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<UserRole, UserRoleDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _userRoleService.RemoveAsync(id));
        }
    }
}
