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
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _roleService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Role, RoleDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _roleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(RoleDto roleDto)
        {
            return CreateActionResult(await _roleService.AddAsync(roleDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {
            return CreateActionResult(await _roleService.UpdateAsync(roleDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Role, RoleDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _roleService.RemoveAsync(id));
        }
    }
}
