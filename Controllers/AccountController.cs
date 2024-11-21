using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Okta_Cookie_Auth.Controllers
{
    // Not used with this controller only used for cookie authetication but this is openId authetication
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Not usefull after including Okta Authetication
       /* [HttpPost]
        public async Task<IActionResult> Login(string urn, string pwd)
        {
            if(urn == "Sree" && pwd == "1234")
            {
                var claims = new List<Claim>();

                ClaimsIdentity identity = new ClaimsIdentity(claims,"Cookie_Scheme");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
            }
            return View();
        }*/
    }
}
