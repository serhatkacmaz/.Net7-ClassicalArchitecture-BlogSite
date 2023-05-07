using BlogSite.Core.Entities.Transaction;

namespace BlogSite.Core.Repositories
{
    public interface IMovementRepository : IGenericRepository<TMovement>
    {
        IQueryable<TMovement> GetAllByBlogIdAndUserId(int blogId, int userId);

    }
}
