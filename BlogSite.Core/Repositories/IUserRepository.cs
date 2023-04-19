using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByMailAsync(string mail);
    }
}
