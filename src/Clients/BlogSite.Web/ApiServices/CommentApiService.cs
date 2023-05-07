using BlogSite.Common.DTOs.Transaction;
using BlogSite.Common.DTOs;

namespace BlogSite.Web.ApiServices
{
    public class CommentApiService
    {
        private readonly HttpClient _httpClient;

        public CommentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BlogSiteResponseDto<TCommentDto>> SaveAsync(TCommentDto commentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("comment", commentDto);
            return await response.Content.ReadFromJsonAsync<BlogSiteResponseDto<TCommentDto>>();
        }

        public async Task<List<TBlogDto>> GetAllByBlogIdAndUserId(int blogId, int userId)
        {
            var response = await _httpClient.GetFromJsonAsync<BlogSiteResponseDto<List<TBlogDto>>>($"comment/GetAllByBlogIdAndUserId/{blogId}/{userId}");
            return response.Data;
        }
    }
}
