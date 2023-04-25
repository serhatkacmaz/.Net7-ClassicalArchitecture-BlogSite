using BlogSite.API.Filters;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        private readonly ICommentService _CommentService;

        public CommentController(ICommentService CommentService)
        {
            _CommentService = CommentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _CommentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TComment, TCommentDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _CommentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TCommentDto CommentDto)
        {
            return CreateActionResult(await _CommentService.AddAsync(CommentDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TCommentDto CommentDto)
        {
            return CreateActionResult(await _CommentService.UpdateAsync(CommentDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TComment, TCommentDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _CommentService.RemoveAsync(id));
        }
    }
}
