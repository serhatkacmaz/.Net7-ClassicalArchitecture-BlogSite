using BlogSite.Common.DTOs.Master;
using BlogSite.Common.DTOs.Transaction;
using BlogSite.Common.DTOs.UserBase;
using BlogSite.Web.ApiServices;
using BlogSite.Web.Helpers;
using BlogSite.Web.Models.UserDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BlogSite.Web.Controllers
{
    [Authorize(Roles = "BlogSiteUser")]
    public class UserDashboardController : Controller
    {
        private readonly BlogApiService _blogApiService;
        private readonly UserApiService _userApiService;
        private readonly CategoryApiService _categoryApiService;
        public int _userId { get => int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault()); }

        public UserDashboardController(BlogApiService blogApiService, UserApiService userApiService, CategoryApiService categoryApiService)
        {
            _blogApiService = blogApiService;
            _userApiService = userApiService;
            _categoryApiService = categoryApiService;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userApiService.GetByIdAsync(_userId));
        }
        #endregion

        #region Blog
        public async Task<IActionResult> BlogGrid()
        {
            var modelList = new List<BlogListViewModel>();
            var blogList = await _blogApiService.GetByUserIdAsync(_userId);
        
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
        public async Task<IActionResult> CreateNewBlog()
        {
            var categoryList = await _categoryApiService.GetAllAsync();
            var categoriesSelectList = new SelectList(categoryList, "Id", "Name");
            ViewBag.CategoriesSelectList = categoriesSelectList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBlog(TBlogDto blogDto, List<IFormFile> files)
        {
            try
            {
                blogDto.User_ID = _userId;

                var responseDto = await _blogApiService.SaveAsync(blogDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                //foreach (var item in files)
                //{
                //    using (var stream = new MemoryStream())
                //    {
                //        await item.CopyToAsync(stream);
                //        userDto.Image = stream.ToArray();
                //    }
                //}
                //using (var stream = new MemoryStream())
                //{
                //    await avatarImage.CopyToAsync(stream);
                //    userDto.Image = stream.ToArray();
                //}

                return RedirectToAction(nameof(BlogGrid));
            }
            catch
            {
                //TODO:
                var categoryList = await _categoryApiService.GetAllAsync();
                var categoriesSelectList = new SelectList(categoryList, "Id", "Name");
                ViewBag.CategoriesSelectList = categoriesSelectList;

                return View();
            }
        }

        public async Task<IActionResult> BlogEdit(int id)
        {
            return View(await _blogApiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> BlogEdit(TBlogDto blogDto)
        {
            try
            {
                var result = await _blogApiService.UpdateAsync(blogDto);

                if (!result)
                    return View();
                else
                    return RedirectToAction(nameof(blogDto));
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
            return View(await _userApiService.GetByIdAsync(_userId));
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserDto userDto, IFormFile avatarImage)
        {
            try
            {
                if (avatarImage != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await avatarImage.CopyToAsync(stream);
                        userDto.Image = stream.ToArray();
                    }
                }

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
