using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Services
{
    public interface IUserRoleService : IService<UserRole, UserRoleDto>
    {
        Task<BlogSiteResponseDto<List<string>>> GetRoleByUserIdAsync(int userId);
    }
}
