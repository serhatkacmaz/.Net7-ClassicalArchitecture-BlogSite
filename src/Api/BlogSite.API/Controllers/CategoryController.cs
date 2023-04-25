using BlogSite.API.Filters;
using BlogSite.Common.DTOs.Master;
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
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<MCategory, MCategoryDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _categoryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MCategoryDto categoryDto)
        {
            categoryDto.ReferenceId = await _categoryService.LastCategoryPKAsync();
            return CreateActionResult(await _categoryService.AddAsync(categoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MCategoryDto categoryDto)
        {
            return CreateActionResult(await _categoryService.UpdateAsync(categoryDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<MCategory, MCategoryDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _categoryService.RemoveAsync(id));
        }
    }
}
