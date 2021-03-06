﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace PrairieCodeIdentity.Identity
{
    public class CustomStore : IUserStore<CustomUser>, IUserPasswordStore<CustomUser>, IUserClaimStore<CustomUser>
    {
        private readonly List<CustomUser> users;

        public CustomStore()
        {
            users = new List<CustomUser>()
            {
                new CustomUser() {Id = 1, UserName = "ondrej"},
                new CustomUser() {Id = 2, UserName = "james"}
            };
        }

        public Task<IdentityResult> CreateAsync(CustomUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Failed());
        }

        public Task<IdentityResult> DeleteAsync(CustomUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Failed());
        }

        public void Dispose()
        {
        }

        public Task<CustomUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(users.FirstOrDefault(user => user.Id.ToString() == userId));
        }

        public Task<CustomUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return
                Task.FromResult(
                    users.FirstOrDefault(
                        user =>
                            string.Equals(user.UserName, normalizedUserName, StringComparison.CurrentCultureIgnoreCase)));
        }

        public Task<string> GetNormalizedUserNameAsync(CustomUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName.ToLower());
        }

        public async Task<string> GetUserIdAsync(CustomUser user, CancellationToken cancellationToken)
        {
            var u = await FindByNameAsync(user.UserName, cancellationToken);
            return u.Id.ToString();
        }

        public async Task<string> GetUserNameAsync(CustomUser user, CancellationToken cancellationToken)
        {
            var u = await FindByIdAsync(user.Id.ToString(), cancellationToken);
            return u.UserName;
        }

        public async Task SetNormalizedUserNameAsync(CustomUser user, string normalizedName,
            CancellationToken cancellationToken)
        {
            await SetUserNameAsync(user, normalizedName, cancellationToken);
        }

        public async Task SetUserNameAsync(CustomUser user, string userName, CancellationToken cancellationToken)
        {
            var u = await FindByIdAsync(user.Id.ToString(), cancellationToken);
            u.UserName = userName.ToLower();
        }

        public Task<IdentityResult> UpdateAsync(CustomUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Failed());
        }

        public Task<string> GetPasswordHashAsync(CustomUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult("");
        }

        public Task<bool> HasPasswordAsync(CustomUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<IList<Claim>> GetClaimsAsync(CustomUser user, CancellationToken cancellationToken)
        {
            if(user.Id == 1)
                return Task.FromResult((IList<Claim>) new List<Claim>() {new Claim("VIPNumber", "123")});
            return Task.FromResult((IList<Claim>) new List<Claim>());
        }

        public Task AddClaimsAsync(CustomUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task ReplaceClaimAsync(CustomUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task RemoveClaimsAsync(CustomUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<IList<CustomUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            return Task.FromResult((IList<CustomUser>) users);
        }
    }
}