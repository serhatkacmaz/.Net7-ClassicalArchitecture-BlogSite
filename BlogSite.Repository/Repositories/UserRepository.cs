using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogSiteContext context) : base(context)
        {
        }

        public Task<User> FindByMailAsync(string mail)
        {
            return _context.Users.AsNoTracking().Where(x => x.Mail == mail).SingleOrDefaultAsync();
        }
    }
}
