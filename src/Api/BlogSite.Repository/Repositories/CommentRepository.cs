using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repository.Repositories
{
    public class CommentRepository : GenericRepository<TComment>, ICommentRepository
    {
        public CommentRepository(BlogSiteContext context) : base(context)
        {
        }

        public IQueryable<TComment> GetAllByBlogId(int blogId)
        {
            return _context.TComments.AsNoTracking().Include(s => s.User).Where(s => s.Blog_ID == blogId);
        }
    }
}
