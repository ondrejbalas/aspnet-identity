using System.Security.Claims;
using System.Security.Principal;

namespace NorthwestValleyIdentity.Identity
{
    public class CustomUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Species Species { get; set; }
    }

    //public class CustomUser : ClaimsPrincipal
    //{
    //    public CustomUser(string username)
    //    {
    //        AddIdentity(new GenericIdentity(username));
    //    }
    //}

}