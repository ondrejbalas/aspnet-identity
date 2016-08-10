using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThatConference.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ThatConference.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(SignInManager<CustomUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel userLogin)
        {
            //Response.Cookies.Append("demo.username", userLogin.UserName);

            var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, string.Empty, false, false);

            if (result == SignInResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(userLogin);
            } 
        }

        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Index", "Home");
        }
    }
}