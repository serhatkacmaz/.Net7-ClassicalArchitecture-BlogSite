using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.Services
{
    public interface IBlogService : IService<TBlog, TBlogDto>
    {
        BlogSiteResponseDto<int> GetTotalViewCount();
        BlogSiteResponseDto<int> GetTotalViewCountByUserId(int userId);
        Task<BlogSiteResponseDto<List<TBlogDto>>> GetByUserIdAsync(int userId);

        Task<BlogSiteResponseDto<List<TBlogDto>>> GetAllWithUser(int page, int pageSize);
    }
}
