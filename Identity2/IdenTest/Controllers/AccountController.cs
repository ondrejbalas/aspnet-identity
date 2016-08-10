using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdenTest.Auth;
using IdenTest.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IdenTest.Controllers
{

    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel userLogin)
        {
            //var loginCookie = new HttpCookie("demo.username", userLogin.UserName);
            //Response.Cookies.Add(loginCookie);

            var signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            var result = await signInManager.PasswordSignInAsync(userLogin.UserName, string.Empty, false, false);

            if (result == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(userLogin);
            }
        }

        public ActionResult Logout()
        {
            //var expiredLoginCookie = new HttpCookie("demo.username");
            //expiredLoginCookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(expiredLoginCookie);

            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}