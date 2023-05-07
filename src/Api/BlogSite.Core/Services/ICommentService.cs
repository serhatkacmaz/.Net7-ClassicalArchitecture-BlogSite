using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.Services
{
    public interface ICommentService : IService<TComment, TCommentDto>
    {
        Task<BlogSiteResponseDto<List<TCommentDto>>> GetAllByBlogIdAndUserId(int blogId, int userId);
    }
}
