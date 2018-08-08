using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ThatConfIden.ThatConf
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<CustomUser, CustomRole>
    {
        public CustomUserClaimsPrincipalFactory(UserManager<CustomUser> userManager,
            RoleManager<CustomRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(CustomUser user)
        {
            var principal = await base.CreateAsync(user);
            var userIdentity = (ClaimsIdentity) principal.Identity;

            // This is where you would normally read properties from your CustomUser object and translate them into Claims that can be used elsewhere in the application.
            userIdentity.AddClaim(new Claim("species", user.Species.ToString()));

            return principal;
        }
    }
}