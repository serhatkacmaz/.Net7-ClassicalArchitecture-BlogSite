using BlogSite.Common.DTOs;
using BlogSite.Common.DTOs.Transaction;

namespace BlogSite.Web.ApiServices
{
    public class BlogApiService
    {
        private readonly HttpClient _httpClient;

        public BlogApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("blog/GetTotalCount");
            return response.Data;
        }

        public async Task<int> GetTotalViewCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("blog/GetTotalViewCount");
            return response.Data;
        }

        public async Task<TBlogDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<TBlogDto>>($"blog/{id}");
            return response.Data;
        }

        public async Task<TBlogDto> GetByIdWithUserAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<TBlogDto>>($"blog/GetByIdWithUser/{id}");
            return response.Data;
        }

        public async Task<List<TBlogDto>> GetByUserIdAsync(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<TBlogDto>>>($"blog/GetByUserId/{userId}");
            return response.Data;
        }


        public async Task<List<TBlogDto>> GetAllWithUser(int page = 1, int pageSize = 5)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<TBlogDto>>>($"blog/GetAllWithUser/{page}/{pageSize}");
            return response.Data;
        }

        public async Task<int> GetTotalBlogCountByUserId(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>($"blog/GetTotalBlogCountByUserId/{userId}");
            return response.Data;
        }

        public async Task<int> GetTotalViewCountByUserId(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>($"blog/GetTotalViewCountByUserId/{userId}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(TBlogDto blogDto)
        {
            var response = await _httpClient.PutAsJsonAsync("blog", blogDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<BlogSiteResponseDto<TBlogDto>> SaveAsync(TBlogDto blogDto)
        {
            var response = await _httpClient.PostAsJsonAsync("blog/save", blogDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<TBlogDto>>();
        }
    }
}
