using BlogSite.API.Filters;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Common.Enums;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : BaseController
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _movementService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TMovement, TMovementDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _movementService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TMovementDto MovementDto)
        {
            return CreateActionResult(await _movementService.AddAsync(MovementDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TMovementDto MovementDto)
        {
            return CreateActionResult(await _movementService.UpdateAsync(MovementDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TMovement, TMovementDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _movementService.RemoveAsync(id));
        }

        //->
        [HttpGet("GetTotalBlogLikeCount")]
        public IActionResult GetTotalBlogLikeCount()
        {
            return CreateActionResult(_movementService.Count(x => x.EUserReaction == EUserReaction.Like && x.IsActive));
        }

        [HttpGet("GetTotalBlogDisLikeCount")]
        public IActionResult GetTotalBlogDisLikeCount()
        {
            return CreateActionResult(_movementService.Count(x => x.EUserReaction == EUserReaction.DisLike && x.IsActive));
        }

        [HttpGet("GetTotalFavoriteCount")]
        public IActionResult GetTotalFavoriteCount()
        {
            return CreateActionResult(_movementService.Count(x => x.EUserReaction == EUserReaction.Favorite && x.IsActive));
        }
    }
}
