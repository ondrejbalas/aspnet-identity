using System.Security.Claims;
using System.Security.Principal;

namespace FoxConIdentity2.Foxcon
{
    public class CustomUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Species Species { get; set; }
    }
}