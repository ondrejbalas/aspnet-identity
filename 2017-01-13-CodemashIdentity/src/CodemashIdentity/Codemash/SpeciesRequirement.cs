using Microsoft.AspNetCore.Authorization;

namespace CodemashIdentity.Codemash
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