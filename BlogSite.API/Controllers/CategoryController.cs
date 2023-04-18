using BlogSite.API.Filters;
using BlogSite.Core.DTOs.Master;
using BlogSite.Core.Entities.Master;
using BlogSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _CategoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<MCategory, MCategoryDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _CategoryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MCategoryDto CategoryDto)
        {
            return CreateActionResult(await _CategoryService.AddAsync(CategoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MCategoryDto CategoryDto)
        {
            return CreateActionResult(await _CategoryService.UpdateAsync(CategoryDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<MCategory, MCategoryDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _CategoryService.RemoveAsync(id));
        }
    }
}
