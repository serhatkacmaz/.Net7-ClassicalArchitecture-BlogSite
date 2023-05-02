using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class BlogRepository : GenericRepository<TBlog>, IBlogRepository
    {
        public BlogRepository(BlogSiteContext context) : base(context)
        {
        }

        public IQueryable<TBlog> GetByUserIdAsync(int userId)
        {
            return _context.TBlogs.Where(x => x.User_ID == userId);
        }

        public int GetTotalViewCountByUserId(int userId)
        {
            return _context.TBlogs.Where(x => x.User_ID == userId).Sum(x => x.ViewNumber);
        }

        public int GetTotalViewCount()
        {
            return _context.TBlogs.Where(x => x.IsActive).Sum(x => x.ViewNumber);
        }
    }
}
