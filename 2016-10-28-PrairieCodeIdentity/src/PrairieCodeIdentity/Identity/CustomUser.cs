﻿using System.Security.Claims;
using System.Security.Principal;

namespace PrairieCodeIdentity.Identity
{
    //public class CustomUser : ClaimsPrincipal
    //{
    //    public CustomUser(string username)
    //    {
    //        AddIdentity(new GenericIdentity(username));
    //    }
    //}

    public class CustomUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}