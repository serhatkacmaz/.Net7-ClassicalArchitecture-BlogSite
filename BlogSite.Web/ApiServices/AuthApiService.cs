using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.JWT;

namespace BlogSite.Web.ApiServices
{
    public class AuthApiService
    {
        private readonly HttpClient _httpClient;

        public AuthApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BlogSiteResponseDto<TokenDto>> CreateToken(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/CreateToken", loginDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<TokenDto>>();
        }

        public async Task<BlogSiteResponseDto<TokenDto>> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/CreateTokenByRefreshToken", refreshTokenDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<TokenDto>>();
        }
    }
}
