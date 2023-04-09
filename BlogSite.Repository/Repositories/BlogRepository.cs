using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class BlogRepository : GenericRepository<TBlog>, IBlogRepository
    {
        public BlogRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
