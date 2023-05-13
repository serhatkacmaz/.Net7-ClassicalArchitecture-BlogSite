using BlogSite.API.Filters;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Services;
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

        [HttpPost("Save")]
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
        [HttpGet("[action]")]
        public IActionResult GetTotalCount()
        {
            return CreateActionResult(_blogService.Count(x => x.IsActive));
        }

        [HttpGet("[action]")]
        public IActionResult GetTotalViewCount()
        {
            return CreateActionResult(_blogService.GetTotalViewCount());
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult GetTotalViewCountByUserId(int userId)
        {
            return CreateActionResult(_blogService.GetTotalViewCountByUserId(userId));
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return CreateActionResult(await _blogService.GetByUserIdAsync(userId));
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult GetTotalBlogCountByUserId(int userId)
        {
            return CreateActionResult(_blogService.Count(x => x.User_ID == userId));
        }

        [HttpGet("[action]/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllWithUser(int page, int pageSize)
        {
            return CreateActionResult(await _blogService.GetAllWithUser(page, pageSize));
        }

        [HttpGet("[action]/{id}/")]
        public async Task<IActionResult> GetByIdWithUser(int id)
        {
            return CreateActionResult(await _blogService.GetByIdWithUser(id));
        }

    }
}
