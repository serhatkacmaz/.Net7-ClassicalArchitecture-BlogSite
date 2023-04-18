using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.Repositories
{
    public interface IBlogRepository : IGenericRepository<TBlog>
    {
        int GetTotalViewCount();

        IQueryable<TBlog> GetByUserIdAsync(int userId);
    }
}
