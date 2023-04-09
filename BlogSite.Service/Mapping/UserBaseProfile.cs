using AutoMapper;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Service.Mapping
{
    public class UserBaseProfile : Profile
    {
        public UserBaseProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
        }
    }
}
