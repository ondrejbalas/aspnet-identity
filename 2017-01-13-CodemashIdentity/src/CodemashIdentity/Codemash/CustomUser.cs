using System.Security.Claims;
using System.Security.Principal;

namespace CodemashIdentity.Codemash
{
    public class CustomUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Species MySpecies { get; set; }
    }
}