using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Services
{
    public interface IAuthenticationService
    {
        Task<BlogSiteResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<BlogSiteResponseDto<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);

        Task<BlogSiteResponseDto<NoContentDto>> RevokeRefreshTokenAsync(string refreshToken);

        BlogSiteResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
