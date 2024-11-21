using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Okta_Cookie_Auth.Models;
using System.Diagnostics;

namespace Okta_Cookie_Auth.Controllers
{
    //Push Checking 
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Autheticate()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookie_Scheme");

            if (User.Identity.IsAuthenticated)
            {
                TempData["AlertMessage"] = "You have successfully cleared all cookies and redirecting to Index page";
            }
            else
            {
                TempData["AlertMessage"] = "User not authenticated so no cookies are available and redricting to Index page";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Varification()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Other()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
