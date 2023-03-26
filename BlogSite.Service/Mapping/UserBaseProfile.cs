using AutoMapper;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
