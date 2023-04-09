using BlogSite.API.Filters;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : BaseController
    {
        private readonly IImageService _ImageService;

        public ImageController(IImageService ImageService)
        {
            _ImageService = ImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _ImageService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TImage, TImageDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _ImageService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TImageDto ImageDto)
        {
            return CreateActionResult(await _ImageService.AddAsync(ImageDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TImageDto ImageDto)
        {
            return CreateActionResult(await _ImageService.UpdateAsync(ImageDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TImage, TImageDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _ImageService.RemoveAsync(id));
        }
    }
}
