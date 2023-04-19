using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;

namespace BlogSite.Repository.Repositories
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
