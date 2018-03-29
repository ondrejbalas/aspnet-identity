using Microsoft.AspNetCore.Authorization;

namespace CplIden.CodePalousa
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