using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
