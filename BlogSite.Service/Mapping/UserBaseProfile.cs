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
            CreateMap<UserRole, UserRoleDto>()
                     .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                     .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<UserRoleDto, UserRole>();
        }
    }
}
