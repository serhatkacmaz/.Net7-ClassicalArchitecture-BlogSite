using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.JWT;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Services
{
    public interface IUserService : IService<User, UserDto>
    {
        Task<BlogSiteResponseDto<UserDto>> GetUserByNameAsync(string name);
    }
}
