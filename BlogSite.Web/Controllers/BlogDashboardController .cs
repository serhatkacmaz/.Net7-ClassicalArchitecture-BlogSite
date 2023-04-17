using BlogSite.Core.DTOs.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class BlogDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
