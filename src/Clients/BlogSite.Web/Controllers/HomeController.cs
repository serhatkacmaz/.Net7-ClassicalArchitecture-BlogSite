using BlogSite.Common.DTOs.Transaction;
using BlogSite.Common.Enums;
using BlogSite.Web.ApiServices;
using Microsoft.AspNetCore.Authorization;
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
            HttpContext.Session.SetInt32("Like", 0);
            HttpContext.Session.SetInt32("DisLike", 0);
            HttpContext.Session.SetInt32("Favorite", 0);

            ViewData["Like"] = 0;
            ViewData["DisLike"] = 0;
            ViewData["Favorite"] = 0;


            var movementList = await _movementApiService.GetAllByBlogIdAndUserId(id, _userId);
            foreach (var item in movementList)
            {
                switch (item.EUserReaction)
                {
                    case EUserReaction.Like:
                        HttpContext.Session.SetInt32("Like", 1);
                        break;
                    case EUserReaction.DisLike:
                        HttpContext.Session.SetInt32("DisLike", 1);
                        break;
                    case EUserReaction.Favorite:
                        HttpContext.Session.SetInt32("Favorite", 1);
                        break;
                    default:
                        break;
                }
            }

            ViewBag.Like = HttpContext.Session.GetInt32("Like");
            ViewBag.DisLike = HttpContext.Session.GetInt32("DisLike");
            ViewBag.Favorite = HttpContext.Session.GetInt32("Favorite");

            //viewCount
            model.ViewNumber = model.ViewNumber + 1;
            await _blogApiService.UpdateAsync(model);

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> MovementAdd(int blogId, byte type)
        {
            if (type == 0)
            {
                return RedirectToAction("Home", "BlogReading", new { id = blogId });
            }

            var movementList = await _movementApiService.GetAllByBlogIdAndUserId(blogId, _userId);
            if (movementList.Count > 0)
            {
                var recordCheck = movementList.FirstOrDefault(s => s.EUserReaction == (EUserReaction)type);
                if (recordCheck != null) //kendisi varsa sil
                {
                    var ret = _movementApiService.Remove(recordCheck.Id);
                    return RedirectToAction("BlogReading", "Home", new { id = blogId });
                }

                //Begeni attıysa, dislike varsa dislke sil, begeni ekle
                var dislikeCheck = movementList.FirstOrDefault(s => s.EUserReaction == EUserReaction.DisLike);
                if (dislikeCheck != null && (EUserReaction)type == EUserReaction.Like)
                {
                    var ret = _movementApiService.Remove(dislikeCheck.Id);
                }

                //Dislike attıysa, like varsa -> like sil, dislike ekle.
                var likeCheck = movementList.FirstOrDefault(s => s.EUserReaction == EUserReaction.Like);
                if (likeCheck != null && (EUserReaction)type == EUserReaction.DisLike)
                {
                    var ret = _movementApiService.Remove(likeCheck.Id);
                }

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

        [Authorize]
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