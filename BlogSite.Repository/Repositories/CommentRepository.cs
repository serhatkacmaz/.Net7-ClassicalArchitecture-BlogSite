using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class CommentRepository : GenericRepository<TComment>, ICommentRepository
    {
        public CommentRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
