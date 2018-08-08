using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThatConfIden.ThatConf;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ThatConfIden.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<CustomUser> _signinManager;

        public AccountController(SignInManager<CustomUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel userLogin)
        {

            var result = await _signinManager.PasswordSignInAsync(userLogin.UserName, string.Empty, false, false);

            if (result == SignInResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(userLogin);
            } 

            //Response.Cookies.Append("demo.username", userLogin.UserName);
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> LogOff()
        {
            await _signinManager.SignOutAsync();

            //Response.Cookies.Delete("demo.username");
            return RedirectToAction("Index", "Home");
        }
    }
}