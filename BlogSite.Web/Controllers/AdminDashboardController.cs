using BlogSite.Web.ApiServices;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly UserApiService _adminDashboardApiService;

        public AdminDashboardController(UserApiService adminDashboardApiService)
        {
            _adminDashboardApiService = adminDashboardApiService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboardVievModel();
            model.ActiveUserCount = await _adminDashboardApiService.GetUserCountAsync();

            return View(model);
        }
    }
}
