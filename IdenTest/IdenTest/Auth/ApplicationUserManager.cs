using System.Security.Cryptography.X509Certificates;
using IdenTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace IdenTest.Auth
{
    public class ApplicationUserManager : UserManager<CustomUser, int>
    {
        public ApplicationUserManager(IUserStore<CustomUser, int> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new ApplicationStore());
            manager.PasswordHasher = new NoPasswordHasher();

            return manager;
        }
    }

    public class NoPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return PasswordVerificationResult.Success;
        }
    }
}