using Microsoft.AspNetCore.Authorization;

namespace NorthwestValleyIdentity.Identity
{
    public class SpeciesRequirement : IAuthorizationRequirement
    {
        public Species RequiredSpecies { get; }

        public SpeciesRequirement(Species species)
        {
            RequiredSpecies = species;
        }
    }
}