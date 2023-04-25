using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Repository.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(BlogSiteContext context) : base(context)
        {
        }

        public async Task<List<string>> GetRolesByUserIdAsync(int userId)
        {
            var userRoleList = await _context.UserRoles
                .Include(x => x.Role)
                .Where(x => x.User_ID == userId)
                .Select(x => x.Role.Name)
                .ToListAsync();

            return userRoleList;
        }
    }
}
