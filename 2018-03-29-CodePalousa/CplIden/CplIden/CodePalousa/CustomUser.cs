using System.Security.Claims;
using System.Security.Principal;

namespace CplIden.CodePalousa
{
    public class CustomUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Species Species { get; set; }
    }
}