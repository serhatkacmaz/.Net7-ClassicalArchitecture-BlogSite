using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Repositories
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<List<string>> GetRolesByUserIdAsync(int userId);
    }
}
