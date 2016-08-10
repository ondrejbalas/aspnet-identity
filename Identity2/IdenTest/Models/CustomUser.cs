using System;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace IdenTest.Models
{
    public class CustomUser : IUser<int>
    {
        public bool IsInRole(string role)
        {
            return false;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
    }
}