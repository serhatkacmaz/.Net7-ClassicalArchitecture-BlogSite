using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Services
{
    public interface IRoleService : IService<Role, RoleDto, int>
    {
    }
}
