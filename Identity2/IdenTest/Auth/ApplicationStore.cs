using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdenTest.Models;
using Microsoft.AspNet.Identity;

namespace IdenTest.Auth
{
    public class ApplicationStore : 
        IUserStore<CustomUser, int>, 
        IUserLockoutStore<CustomUser, int>, 
        IUserPasswordStore<CustomUser, int>,
        IUserTwoFactorStore<CustomUser, int>
    {
        private List<CustomUser> _users;  
        public ApplicationStore()
        {
            _users = new List<CustomUser>()
            {
                new CustomUser() { Id = 1, UserName = "ondrej" }
            };
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(CustomUser user)
        {
            return Task.FromResult(0);
        }

        public Task UpdateAsync(CustomUser user)
        {
            return Task.FromResult(0);
        }

        public Task DeleteAsync(CustomUser user)
        {
            return Task.FromResult(0);
        }

        public Task<CustomUser> FindByIdAsync(int userId)
        {
            return Task.FromResult(_users.FirstOrDefault(user => user.Id == userId));
        }

        public Task<CustomUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(_users.FirstOrDefault(user => user.UserName == userName));
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(CustomUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(CustomUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(CustomUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            return Task.FromResult("password");
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            return Task.FromResult(true);
        }

        public Task SetTwoFactorEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(CustomUser user)
        {
            return Task.FromResult(false);
        }
    }
}