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
        private readonly MovementApiService _movementApiService;
        public int _userId
        {
            get
            {
                var nameIdentifierClaim = User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (nameIdentifierClaim != null)
                {
                    return int.Parse(nameIdentifierClaim.Value);
                }

                return default(int);
            }
        }

        public UserDashboardController(BlogApiService blogApiService, UserApiService userApiService, CategoryApiService categoryApiService, MovementApiService movementApiService)
        {
            _blogApiService = blogApiService;
            _userApiService = userApiService;
            _categoryApiService = categoryApiService;
            _movementApiService = movementApiService;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogCountTask = _blogApiService.GetTotalBlogCountByUserId(_userId);
            var viewCountTask = _blogApiService.GetTotalViewCountByUserId(_userId);
            var likeCountTask = _movementApiService.GetTotalBlogLikeCountByUserIdAsync(_userId);
            var dislikeCountTask = _movementApiService.GetTotalBlogDisLikeCountByUserIdAsync(_userId);
            var userTask = _userApiService.GetByIdAsync(_userId);

            await Task.WhenAll(blogCountTask, viewCountTask, likeCountTask, dislikeCountTask, userTask);

            var model = new UserTrackingViewModel()
            {
                FullName = userTask.Result.UserName,
                Title = userTask.Result.Title,
                About = userTask.Result.About,
                Image = userTask.Result.Image,
                CreatedDate = userTask.Result.CreatedDate,
                BlogCount = blogCountTask.Result,
                ViewCount = viewCountTask.Result,
                TotalLikeCount = likeCountTask.Result,
                TotalDislikeCount = dislikeCountTask.Result,
            };

            return View(model);
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
                    Id = item.Id,
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
        public async Task<IActionResult> CreateNewBlog(TBlogDto blogDto, IFormFile coverImg, IFormFile headerImg, IFormFile contentImg)
        {
            try
            {
                blogDto.User_ID = _userId;

                if (coverImg != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await coverImg.CopyToAsync(stream);
                        blogDto.CoverImg = stream.ToArray();
                    }
                }

                if (headerImg != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await headerImg.CopyToAsync(stream);
                        blogDto.HeaderImg = stream.ToArray();
                    }
                }

                if (contentImg != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await contentImg.CopyToAsync(stream);
                        blogDto.ContentImg = stream.ToArray();
                    }
                }

                var responseDto = await _blogApiService.SaveAsync(blogDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(BlogGrid));
            }
            catch
            {
                var categoryList = await _categoryApiService.GetAllAsync();
                var categoriesSelectList = new SelectList(categoryList, "Id", "Name");
                ViewBag.CategoriesSelectList = categoriesSelectList;

                return View();
            }
        }

        public async Task<IActionResult> BlogEdit(int id)
        {
            var categoryList = await _categoryApiService.GetAllAsync();
            var categoriesSelectList = new SelectList(categoryList, "Id", "Name");
            ViewBag.CategoriesSelectList = categoriesSelectList;

            return View(await _blogApiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> BlogEdit(TBlogDto blogDto, IFormFile coverImg, IFormFile headerImg, IFormFile contentImg)
        {
            try
            {
                if (coverImg != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await coverImg.CopyToAsync(stream);
                        blogDto.CoverImg = stream.ToArray();
                    }
                }

                if (headerImg != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await headerImg.CopyToAsync(stream);
                        blogDto.HeaderImg = stream.ToArray();
                    }
                }

                if (contentImg != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await contentImg.CopyToAsync(stream);
                        blogDto.ContentImg = stream.ToArray();
                    }
                }

                var result = await _blogApiService.UpdateAsync(blogDto);

                if (!result)
                    return View();
                else
                    return RedirectToAction(nameof(BlogGrid));
            }
            catch
            {
                var categoryList = await _categoryApiService.GetAllAsync();
                var categoriesSelectList = new SelectList(categoryList, "Id", "Name");
                ViewBag.CategoriesSelectList = categoriesSelectList;


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
