using BlogSite.Core.DTOs.Master;
using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Web.ApiServices;
using BlogSite.Web.Helpers;
using BlogSite.Web.Models;
using BlogSite.Web.Models.UserDashboard;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class UserDashboardController : Controller
    {
        private readonly BlogApiService _blogApiService;
        private readonly UserApiService _userApiService;

        public UserDashboardController(BlogApiService blogApiService, UserApiService userApiService)
        {
            _blogApiService = blogApiService;
            _userApiService = userApiService;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userApiService.GetByIdAsync(1));
        }
        #endregion

        #region Blog
        [HttpGet]
        public async Task<IActionResult> BlogGrid()
        {
            var modelList = new List<BlogListViewModel>();
            var blogList = await _blogApiService.GetByUserIdAsync(1); //TODO: userID

            foreach (var item in blogList)
            {
                modelList.Add(new BlogListViewModel()
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
        public async Task<IActionResult> CreateNewBlog(TBlogDto blogDto)
        {
            try
            {
                //TODO:
                blogDto.Category_ID = 1;
                blogDto.User_ID = 1;

                var responseDto = await _blogApiService.SaveAsync(blogDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Profile
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View(await _userApiService.GetByIdAsync(1));
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserDto userDto)
        {
            try
            {
                userDto.User_ID = 1; //TODO:
                var result = await _userApiService.UpdateAsync(userDto);

                if (!result)
                    return View();
                else
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
