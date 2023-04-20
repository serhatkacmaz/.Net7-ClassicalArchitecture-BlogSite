using AutoMapper;
using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace BlogSite.Service.Services
{
    public class UserRoleService : Service<UserRole, UserRoleDto>, IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleService(IGenericRepository<UserRole> repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRoleRepository userRoleRepository) : base(repository, unitOfWork, mapper)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<BlogSiteResponseDto<List<string>>> GetRoleByUserIdAsync(int userId)
        {
            var list = await _userRoleRepository.GetRolesByUserIdAsync(userId);
            var dtoList = _mapper.Map<List<string>>(list);

            return BlogSiteResponseDto<List<string>>.Success(StatusCodes.Status200OK, dtoList);
        }

    }
}
