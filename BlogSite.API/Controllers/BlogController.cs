using BlogSite.API.Filters;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Services;
using BlogSite.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _blogService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TBlog, TBlogDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _blogService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TBlogDto blogDto)
        {
            return CreateActionResult(await _blogService.AddAsync(blogDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TBlogDto blogDto)
        {
            return CreateActionResult(await _blogService.UpdateAsync(blogDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TBlog, TBlogDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _blogService.RemoveAsync(id));
        }


        //->
        [HttpGet("GetTotalCount")]
        public IActionResult GetTotalCount()
        {
            return CreateActionResult(_blogService.Count(x => x.IsActive));
        }

    }
}
