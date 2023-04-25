using AutoMapper;
using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Service.Services
{
    public class UserService : Service<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) : base(repository, unitOfWork, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<BlogSiteResponseDto<UserDto>> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.Where(x => x.Name == name).SingleOrDefaultAsync();

            if (user is null)
                return BlogSiteResponseDto<UserDto>.Fail(StatusCodes.Status404NotFound, "Name not found");

            var userDto = _mapper.Map<UserDto>(user);
            return BlogSiteResponseDto<UserDto>.Success(StatusCodes.Status200OK, userDto);

        }
    }
}
