using BlogSite.Core.DTOs;

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

        public async Task<int> GetTotalBlogDisLikeCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("movement/GetTotalBlogDisLikeCount");
            return response.Data;
        }

        public async Task<int> GetTotalFavoriteCountAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("movement/GetTotalFavoriteCount");
            return response.Data;
        }
    }
}
