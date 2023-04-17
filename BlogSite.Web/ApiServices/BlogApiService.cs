using BlogSite.Core.DTOs;

namespace BlogSite.Web.ApiServices
{
    public class BlogApiService
    {

        private readonly HttpClient _httpClient;

        public BlogApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCount()
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<int>>("blog/GetTotalCount");
            return response.Data;
        }
    }
}
