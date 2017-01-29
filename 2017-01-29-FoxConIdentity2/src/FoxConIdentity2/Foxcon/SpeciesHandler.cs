using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FoxConIdentity2.Foxcon
{
    public class SpeciesHandler : AuthorizationHandler<SpeciesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            SpeciesRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "species"))
            {
                return Task.CompletedTask;
            }

            Species species;
            if (!Enum.TryParse(context.User.FindFirst(c => c.Type == "species").Value, out species))
            {
                return Task.CompletedTask;
            }

            if (species == requirement.RequiredSpecies)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}