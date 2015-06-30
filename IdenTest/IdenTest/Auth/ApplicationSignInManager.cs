using IdenTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace IdenTest.Auth
{
    public class ApplicationSignInManager : SignInManager<CustomUser, int>
    {
        public ApplicationSignInManager(UserManager<CustomUser, int> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {

        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}