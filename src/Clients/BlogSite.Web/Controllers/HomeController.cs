using BlogSite.Web.ApiServices;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        BlogApiService _blogApiService;
        UserApiService _userApiService;

        public HomeController(BlogApiService blogApiService, UserApiService userApiService)
        {
            _blogApiService = blogApiService;
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            ViewBag.PageNum = page ?? 1;
            if ((int)ViewBag.PageNum == 1)
            {
                ViewBag.PagePrevNum = 1;
                ViewBag.PageNum = 2;
                ViewBag.PageNextNum = 3;
            }
            else
            {
                ViewBag.PagePrevNum = page - 1;
                ViewBag.PageNum = page;
                ViewBag.PageNextNum = page + 1;
            }

            var model = await _blogApiService.GetAllWithUser(page ?? 1);
            return View(model);
        }

    }
}