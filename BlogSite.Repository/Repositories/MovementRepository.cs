using BlogSite.Core.Entities.Transaction;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class MovementRepository : GenericRepository<TMovement>, IMovementRepository
    {
        public MovementRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
