using BlogSite.Web.ApiServices;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly UserApiService _adminDashboardApiService;
        private readonly BlogApiService _blogApiService;
        private readonly MovementApiService _movementApiService;

        public AdminDashboardController(UserApiService adminDashboardApiService, BlogApiService blogApiService, MovementApiService movementApiService)
        {
            _adminDashboardApiService = adminDashboardApiService;
            _blogApiService = blogApiService;
            _movementApiService = movementApiService;
        }

        public async Task<IActionResult> Index()
        {
            var userCountTask = _adminDashboardApiService.GetUserCountAsync();
            var viewCountTask = _blogApiService.GetTotalViewCountAsync();
            var totalCountTask = _blogApiService.GetTotalCountAsync();
            var likeCountTask = _movementApiService.GetTotalBlogLikeCountAsync();
            var dislikeCountTask = _movementApiService.GetTotalBlogDisLikeCountAsync();
            var favoriteCountTask = _movementApiService.GetTotalFavoriteCountAsync();

            await Task.WhenAll(userCountTask, viewCountTask, totalCountTask, likeCountTask, favoriteCountTask);

            var model = new AdminDashboardVievModel()
            {
                UserCount = userCountTask.Result,
                ViewCount = viewCountTask.Result,
                TotalCount = totalCountTask.Result,
                LikeCount = likeCountTask.Result,
                DislikeCount = dislikeCountTask.Result,
                FavoriteCount = favoriteCountTask.Result,
            };

            return View(model);
        }
    }
}
