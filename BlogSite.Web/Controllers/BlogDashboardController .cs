using BlogSite.Core.DTOs.Transaction;
using BlogSite.Web.ApiServices;
using BlogSite.Web.Helpers;
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

        [HttpGet]
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
                    CreatedDate = DateTime.Now
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
        public async Task<IActionResult> CreateNewBlog(TBlogDto blogDto)
        {
            try
            {
                //TODO:
                blogDto.Category_ID = 1;
                blogDto.User_ID = 1;

                var responseDto = await _blogApiService.Save(blogDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
