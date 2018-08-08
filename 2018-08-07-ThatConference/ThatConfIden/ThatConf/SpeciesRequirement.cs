using Microsoft.AspNetCore.Authorization;

namespace ThatConfIden.ThatConf
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