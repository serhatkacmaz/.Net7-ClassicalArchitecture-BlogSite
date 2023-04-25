using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.UserBase;

namespace BlogSite.Web.ApiServices
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<UserDto>>>("user/GetAll");
            return response.Data;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<UserDto>>($"user/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
            var response = await _httpClient.PutAsJsonAsync("user", userDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<BlogSiteResponseDto<UserDto>> SaveAsync(UserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("user", userDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<UserDto>>();
        }

        public async Task<int> GetUserCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("user/GetUserCount");
            return response.Data;
        }
    }
}
