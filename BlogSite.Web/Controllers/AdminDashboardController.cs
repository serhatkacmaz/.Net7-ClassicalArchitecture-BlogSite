using BlogSite.Core.DTOs.Master;
using BlogSite.Core.DTOs.UserBase;
using BlogSite.Core.Entities.UserBase;
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
        private readonly UserRoleApiService _userRoleApiService;

        public AdminDashboardController(UserApiService userApiService, BlogApiService blogApiService, MovementApiService movementApiService, CategoryApiService categoryApiService, RoleApiService roleApiService, UserRoleApiService userRoleApiService = null)
        {
            _userApiService = userApiService;
            _blogApiService = blogApiService;
            _movementApiService = movementApiService;
            _categoryApiService = categoryApiService;
            _roleApiService = roleApiService;
            _userRoleApiService = userRoleApiService;
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

        #region UserRole
        [HttpGet]
        public async Task<IActionResult> UserRoleGrid()
        {
            return View(await _userRoleApiService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewUserRole()
        {
            var itemList = new List<SelectListItem>();
            var roleList = await _roleApiService.GetAllAsync();

            itemList.Add(new SelectListItem { Text = "Seçiniz", Value = "0" });
            itemList.AddRange(roleList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));
            ViewBag.RoleDropDownList = itemList;

            itemList = new List<SelectListItem>();
            itemList.Add(new SelectListItem { Text = "Seçiniz", Value = "0" });
            var userList = await _userApiService.GetAllAsync();

            itemList.AddRange(userList.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));
            ViewBag.UserDropDownList = itemList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUserRole(UserRoleDto userRoleDto)
        {
            try
            {
                userRoleDto.IsActive = true; //TODO:
                var responseDto = await _userRoleApiService.SaveAsync(userRoleDto);
                ErrorHelper.ResponseHandler(responseDto, this.ControllerContext);

                return RedirectToAction(nameof(UserRoleGrid));
            }
            catch (Exception)
            {       
                return RedirectToAction(nameof(CreateNewUserRole));
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserRoleDelete(int id)
        {
            var responseDto = await _userRoleApiService.Remove(id);
            return RedirectToAction(nameof(UserRoleGrid));
        }
        #endregion
    }
}
