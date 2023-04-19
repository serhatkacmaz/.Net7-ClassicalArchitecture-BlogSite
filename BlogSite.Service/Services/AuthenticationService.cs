using BlogSite.Core.Configurations;
using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.JWT;
using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using BlogSite.Core.Services;
using BlogSite.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlogSite.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IOptions<List<Client>> optionsClient, ITokenService tokenService, IUserRepository userRepository, IUserRefreshTokenRepository userRefreshTokenRepository, IUnitOfWork unitOfWork)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogSiteResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto is null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _userRepository.FindByMailAsync(loginDto.Mail);

            if (user is null)
                return BlogSiteResponseDto<TokenDto>.Fail(StatusCodes.Status400BadRequest, "Mail or Password is wrong");


            if (user.Password != loginDto.Password)
                return BlogSiteResponseDto<TokenDto>.Fail(StatusCodes.Status400BadRequest, "Mail or Password is wrong");

            var tokenDto = _tokenService.CreateToken(user);
            var userRefreshToken = await _userRefreshTokenRepository.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken is null)
            {
                await _userRefreshTokenRepository.AddAsync(new UserRefreshToken()
                {
                    UserId = user.Id,
                    Code = tokenDto.RefreshToken,
                    Expiration = tokenDto.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = tokenDto.RefreshToken;
                userRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();

            return BlogSiteResponseDto<TokenDto>.Success(StatusCodes.Status200OK, tokenDto);
        }

        public BlogSiteResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientID && x.Secret == clientLoginDto.ClientSecret);

            if (client is null)
                return BlogSiteResponseDto<ClientTokenDto>.Fail(StatusCodes.Status404NotFound, "ClientId or ClientSecret not found");

            var tokenDto = _tokenService.CreateTokenByClient(client);
            return BlogSiteResponseDto<ClientTokenDto>.Success(StatusCodes.Status200OK, tokenDto);
        }

        public async Task<BlogSiteResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken is null)
                return BlogSiteResponseDto<TokenDto>.Fail(StatusCodes.Status404NotFound, "Refresh token not found");

            var user = (await _userRepository.GetByIdAsync(existRefreshToken.UserId));

            if (user is null)
                return BlogSiteResponseDto<TokenDto>.Fail(StatusCodes.Status404NotFound, "User not found");

            var tokenDto = _tokenService.CreateToken(user);
            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();
            return BlogSiteResponseDto<TokenDto>.Success(StatusCodes.Status200OK, tokenDto);
        }

        public async Task<BlogSiteResponseDto<NoContentDto>> RevokeRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken is null)
                return BlogSiteResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Refresh token not found");

            _userRefreshTokenRepository.Remove(existRefreshToken);
            await _unitOfWork.CommitAsync();

            return BlogSiteResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }
    }
}
