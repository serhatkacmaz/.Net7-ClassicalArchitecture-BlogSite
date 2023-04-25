using BlogSite.Web.ApiServices;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSite.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}