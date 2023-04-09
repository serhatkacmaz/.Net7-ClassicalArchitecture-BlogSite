using AutoMapper;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;

namespace BlogSite.Service.Services
{
    public class UserService : Service<User, UserDto>, IUserService
    {
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
