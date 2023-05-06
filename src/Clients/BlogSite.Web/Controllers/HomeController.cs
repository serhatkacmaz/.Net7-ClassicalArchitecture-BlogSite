using BlogSite.Common.DTOs.Transaction;
using BlogSite.Common.Enums;
using BlogSite.Web.ApiServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        BlogApiService _blogApiService;
        UserApiService _userApiService;
        MovementApiService _movementApiService;
        CommentApiService _commentApiService;
        public int _userId { get => int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault()); }

        public HomeController(BlogApiService blogApiService, UserApiService userApiService, MovementApiService movementApiService, CommentApiService commentApiService)
        {
            _blogApiService = blogApiService;
            _userApiService = userApiService;
            _movementApiService = movementApiService;
            _commentApiService = commentApiService;
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

        public async Task<IActionResult> BlogReading(int id)
        {
            var model = await _blogApiService.GetByIdWithUserAsync(id);
            return View(model);
        }

        public async Task<IActionResult> MovementAdd(int blogId, byte type)
        {
            if (type == 0)
            {
                return RedirectToAction("Home", "BlogReading", new { id = blogId });
            }

            var movementModel = new TMovementDto()
            {
                Blog_ID = blogId,
                User_ID = _userId,
                IsActive = true,
                EUserReaction = (EUserReaction)type
            };

            await _movementApiService.SaveAsync(movementModel);
            return RedirectToAction("BlogReading", "Home", new { id = blogId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(int Id, string message)
        {
            var commentModel = new TCommentDto()
            {
                Blog_ID = Id,
                User_ID = _userId,
                IsActive = true,
                Comment = message,
                ParentId = 0,
                Name = "c"
            };

            await _commentApiService.SaveAsync(commentModel);
            return RedirectToAction("BlogReading", "Home", new { id = Id });
        }

    }
}