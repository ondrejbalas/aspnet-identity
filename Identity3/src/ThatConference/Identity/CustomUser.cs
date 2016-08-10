using System.Security.Claims;
using System.Security.Principal;

namespace ThatConference.Identity
{
    public class CustomUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}