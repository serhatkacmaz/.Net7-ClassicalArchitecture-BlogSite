using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
