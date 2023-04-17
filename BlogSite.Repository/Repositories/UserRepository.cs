using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogSiteContext context) : base(context)
        {
        }

        public int ActiveUserCount()
        {
            return _context.Users.Where(u => u.IsActive).Count();
        }
    }
}
