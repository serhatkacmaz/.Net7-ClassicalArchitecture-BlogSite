using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Services
{
    public interface IUserService : IService<User, UserDto>
    {
        Task<BlogSiteResponseDto<UserDto>> GetUserByNameAsync(string name);
    }
}
