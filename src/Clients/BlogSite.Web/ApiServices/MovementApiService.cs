using BlogSite.Common.DTOs;

namespace BlogSite.Web.ApiServices
{
    public class MovementApiService
    {
        private readonly HttpClient _httpClient;

        public MovementApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalBlogLikeCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("movement/GetTotalBlogLikeCount");
            return response.Data;
        }

        public async Task<int> GetTotalBlogLikeCountByUserIdAsync(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>($"movement/GetTotalBlogLikeCountByUserId/{userId}");
            return response.Data;
        }

        public async Task<int> GetTotalBlogDisLikeCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("movement/GetTotalBlogDisLikeCount");
            return response.Data;
        }

        public async Task<int> GetTotalBlogDisLikeCountByUserIdAsync(int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>($"movement/GetTotalBlogDisLikeCountByUserId/{userId}");
            return response.Data;
        }


        public async Task<int> GetTotalFavoriteCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("movement/GetTotalFavoriteCount");
            return response.Data;
        }
    }
}
