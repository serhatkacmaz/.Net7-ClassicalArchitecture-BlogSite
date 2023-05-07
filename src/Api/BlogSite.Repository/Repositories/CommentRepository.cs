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

        public IQueryable<TComment> GetAllByBlogIdAndUserId(int blogId, int userId)
        {
            return _context.TComments.AsNoTracking().Where(s => s.Blog_ID == blogId && s.User_ID == userId);
        }
    }
}
