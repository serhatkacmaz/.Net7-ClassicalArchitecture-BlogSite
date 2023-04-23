using BlogSite.Core.DTOs.Master;
using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.UserBase;

namespace BlogSite.Web.ApiServices
{
    public class RoleApiService
    {
        private readonly HttpClient _httpClient;

        public RoleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<RoleDto>>>("Role/GetAll");
            return response.Data;
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<RoleDto>>($"role/{id}");
            return response.Data;
        }

        public async Task<BlogSiteResponseDto<RoleDto>> SaveAsync(RoleDto roleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("role", roleDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<RoleDto>>();
        }

        public async Task<bool> UpdateAsync(RoleDto roleDto)
        {
            var response = await _httpClient.PutAsJsonAsync("role", roleDto);
            return response.IsSuccessStatusCode;
        }
    }
}
