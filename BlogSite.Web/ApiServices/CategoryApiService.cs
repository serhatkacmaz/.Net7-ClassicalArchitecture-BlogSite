using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.DTOs;
using BlogSite.Core.DTOs.Master;

namespace BlogSite.Web.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MCategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<MCategoryDto>>>("category/GetAll");
            return response.Data;
        }

        public async Task<MCategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<MCategoryDto>>($"category/{id}");
            return response.Data;
        }

        public async Task<BlogSiteResponseDto<MCategoryDto>> SaveAsync(MCategoryDto categoryDto)
        {
            var response = await _httpClient.PostAsJsonAsync("category", categoryDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<MCategoryDto>>();
        }

        public async Task<bool> UpdateAsync(MCategoryDto categoryDto)
        {
            var response = await _httpClient.PutAsJsonAsync("category", categoryDto);
            return response.IsSuccessStatusCode;
        }
    }
}
