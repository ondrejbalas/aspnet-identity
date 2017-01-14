using System.Threading.Tasks;
using CodemashIdentity.Codemash;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CodemashIdentity.Controllers
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

            //await _signInManager.PasswordSignInAsync(userLogin.UserName, string.Empty, false, false);

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

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            //Response.Cookies.Delete("demo.username");
            return RedirectToAction("Index", "Home");
        }
    }
}