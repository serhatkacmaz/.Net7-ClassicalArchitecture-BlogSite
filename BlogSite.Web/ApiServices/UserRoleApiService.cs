using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.DTOs;

namespace BlogSite.Web.ApiServices
{
    public class UserRoleApiService
    {
        private readonly HttpClient _httpClient;

        public UserRoleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserRoleDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<UserRoleDto>>>("UserRole/GetAll");
            return response.Data;
        }

        public async Task<UserRoleDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<UserRoleDto>>($"UserRole/{id}");
            return response.Data;
        }

        public async Task<BlogSiteResponseDto<UserRoleDto>> SaveAsync(UserRoleDto userRoleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("UserRole", userRoleDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<UserRoleDto>>();
        }

        public async Task<bool> UpdateAsync(UserRoleDto userRoleDto)
        {
            var response = await _httpClient.PutAsJsonAsync("UserRole", userRoleDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"UserRole/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
