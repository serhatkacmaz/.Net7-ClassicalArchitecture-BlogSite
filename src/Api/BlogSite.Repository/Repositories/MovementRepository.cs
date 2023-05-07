using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repository.Repositories
{
    public class MovementRepository : GenericRepository<TMovement>, IMovementRepository
    {
        public MovementRepository(BlogSiteContext context) : base(context)
        {
        }

        public IQueryable<TMovement> GetAllByBlogIdAndUserId(int blogId, int userId)
        {
            return _context.TMovements.AsNoTracking().Where(s => s.Blog_ID == blogId && s.User_ID == userId);
        }
    }
}
