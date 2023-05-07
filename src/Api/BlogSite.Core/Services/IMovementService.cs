using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.Services
{
    public interface IMovementService : IService<TMovement, TMovementDto>
    {
        Task<BlogSiteResponseDto<List<TMovementDto>>> GetAllByBlogIdAndUserId(int blogId, int userId);

    }
}
