using Microsoft.AspNetCore.Authorization;

namespace MusicCityIdentity.Identity
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