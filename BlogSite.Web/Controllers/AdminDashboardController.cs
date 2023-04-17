using BlogSite.Web.ApiServices;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly UserApiService _adminDashboardApiService;
        private readonly BlogApiService _blogApiService;

        public AdminDashboardController(UserApiService adminDashboardApiService, BlogApiService blogApiService)
        {
            _adminDashboardApiService = adminDashboardApiService;
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboardVievModel();

            model.ActiveUserCount = await _adminDashboardApiService.GetUserCountAsync();
            model.TotalCount = await _blogApiService.GetTotalCount();

            return View(model);
        }
    }
}
