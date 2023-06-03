using AutoMapper;
using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Service.Services
{
    public class MovementService : Service<TMovement, TMovementDto>, IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        public MovementService(IGenericRepository<TMovement> repository, IUnitOfWork unitOfWork, IMapper mapper, IMovementRepository movementRepository) : base(repository, unitOfWork, mapper)
        {
            _movementRepository = movementRepository;
        }

        public async Task<BlogSiteResponseDto<List<TMovementDto>>> GetAllByBlogIdAndUserId(int blogId, int userId)
        {
            var list = await _movementRepository.GetAllByBlogIdAndUserId(blogId, userId).ToListAsync();
            var dtoList = _mapper.Map<List<TMovementDto>>(list);

            return BlogSiteResponseDto<List<TMovementDto>>.Success(StatusCodes.Status200OK, dtoList);
        }
    }
}
