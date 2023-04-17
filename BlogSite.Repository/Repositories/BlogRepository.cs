using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class BlogRepository : GenericRepository<TBlog>, IBlogRepository
    {
        public BlogRepository(BlogSiteContext context) : base(context)
        {
        }

        public int GetTotalViewCount()
        {
            return _context.TBlogs.Where(x => x.IsActive).Sum(x => x.ViewNumber);
        }
    }
}
