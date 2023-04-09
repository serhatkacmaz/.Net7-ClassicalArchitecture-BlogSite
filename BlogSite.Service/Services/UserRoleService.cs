using AutoMapper;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Service.Services
{
    public class UserRoleService : Service<UserRole, UserRoleDto>, IUserRoleService
    {
        public UserRoleService(IGenericRepository<UserRole> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
