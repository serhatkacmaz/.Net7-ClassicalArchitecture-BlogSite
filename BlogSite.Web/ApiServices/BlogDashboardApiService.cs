namespace BlogSite.Web.ApiServices
{
    public class BlogDashboardApiService
    {

        private readonly HttpClient _httpClient;

        public BlogDashboardApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
