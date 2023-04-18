using BlogSite.Core.DTOs.Transaction;
using BlogSite.Web.ApiServices;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class BlogDashboardController : Controller
    {
        private readonly BlogApiService _blogApiService;

        public BlogDashboardController(BlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IActionResult> Index()
        {
            var modelList = new List<BlogDashboardViewModel>();
            var blogList = await _blogApiService.GetByUserIdAsync(1); //TODO: userID

            foreach (var item in blogList)
            {
                modelList.Add(new BlogDashboardViewModel()
                {
                    Name = item.Name,
                    IsActive = item.IsActive,
                    CreatedDate = item.CreatedDate
                });
            }

            return View(modelList);
        }

        [HttpGet]
        public IActionResult CreateNewBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewBlog(TBlogDto blogDto)
        {
            return View();
        }
    }
}
