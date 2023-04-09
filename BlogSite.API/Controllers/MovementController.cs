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
    public class MovementController : BaseController
    {
        private readonly IMovementService _MovementService;

        public MovementController(IMovementService MovementService)
        {
            _MovementService = MovementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _MovementService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TMovement, TMovementDto>))]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _MovementService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TMovementDto MovementDto)
        {
            return CreateActionResult(await _MovementService.AddAsync(MovementDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TMovementDto MovementDto)
        {
            return CreateActionResult(await _MovementService.UpdateAsync(MovementDto));
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<TMovement, TMovementDto>))]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _MovementService.RemoveAsync(id));
        }
    }
}
