using BlogSite.Core.DTOs.Master;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Web.ApiServices;
using BlogSite.Web.Helpers;
using BlogSite.Web.Models.AdminDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly UserApiService _userApiService;
        private readonly BlogApiService _blogApiService;
        private readonly MovementApiService _movementApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly RoleApiService _roleApiService;

        public AdminDashboardController(UserApiService userApiService, BlogApiService blogApiService, MovementApiService movementApiService, CategoryApiService categoryApiService, RoleApiService roleApiService)
        {
            _userApiService = userApiService;
            _blogApiService = blogApiService;
            _movementApiService = movementApiService;
            _categoryApiService = categoryApiService;
            _roleApiService = roleApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userCountTask = _userApiService.GetUserCountAsync();
            var viewCountTask = _blogApiService.GetTotalViewCountAsync();
            var totalCountTask = _blogApiService.GetTotalCountAsync();
            var likeCountTask = _movementApiService.GetTotalBlogLikeCountAsync();
            var dislikeCountTask = _movementApiService.GetTotalBlogDisLikeCountAsync();
            var favoriteCountTask = _movementApiService.GetTotalFavoriteCountAsync();

            await Task.WhenAll(userCountTask, viewCountTask, totalCountTask, likeCountTask, favoriteCountTask);

            var model = new SiteTrackingVievModel()
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

        #region Category
        [HttpGet]
        public async Task<IActionResult> CategoryGrid()
        {
            return View(await _categoryApiService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult CreateNewCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(MCategoryDto categoryDto)
        {
            try
            {
                var responseDto = await _categoryApiService.SaveAsync(categoryDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(CategoryGrid));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> CategoryEdit(int id)
        {
            return View(await _categoryApiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CategoryEdit(MCategoryDto categoryDto)
        {
            try
            {
                var result = await _categoryApiService.UpdateAsync(categoryDto);

                if (!result)
                    return View();
                else
                    return RedirectToAction(nameof(CategoryGrid));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Role
        [HttpGet]
        public async Task<IActionResult> RoleGrid()
        {
            return View(await _roleApiService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult CreateNewRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewRole(RoleDto roleDto)
        {
            try
            {
                var responseDto = await _roleApiService.SaveAsync(roleDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(RoleGrid));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RoleEdit(int id)
        {
            return View(await _roleApiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleDto roleDto)
        {
            try
            {
                var result = await _roleApiService.UpdateAsync(roleDto);

                if (!result)
                    return View();
                else
                    return RedirectToAction(nameof(RoleGrid));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region User
        [HttpGet]
        public async Task<IActionResult> UserGrid()
        {
            return View(await _userApiService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(UserDto userDto)
        {
            try
            {
                var responseDto = await _userApiService.SaveAsync(userDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(UserGrid));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(int id)
        {
            return View(await _userApiService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDto userDto)
        {
            try
            {
                var result = await _userApiService.UpdateAsync(userDto);

                if (!result)
                    return View();
                else
                    return RedirectToAction(nameof(UserGrid));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
