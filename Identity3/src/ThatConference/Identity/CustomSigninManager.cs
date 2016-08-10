using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ThatConference.Identity
{
    public class CustomSigninManager<T> : SignInManager<T>
    {
        public override Task<SignInResult> PasswordSignInAsync(T user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return base.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

            
        }

        public Task<SignInResult> SignInWithTenant(string username, string password, string tenantId)
        {
            
        }
    }
}