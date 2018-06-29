using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NorthwestValleyIdentity.Identity
{
    public class CustomRoleStore : IRoleStore<CustomRole>
    {
        public Task<IdentityResult> CreateAsync(CustomRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Failed());
        }

        public Task<IdentityResult> DeleteAsync(CustomRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Failed());
        }

        public void Dispose()
        {
        }

        public Task<CustomRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return Task.FromResult<CustomRole>(null);
        }

        public Task<CustomRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return Task.FromResult<CustomRole>(null);
        }

        public Task<string> GetNormalizedRoleNameAsync(CustomRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult<string>(null);
        }

        public Task<string> GetRoleIdAsync(CustomRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult<string>(null);
        }

        public Task<string> GetRoleNameAsync(CustomRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult<string>(null);
        }

        public Task SetNormalizedRoleNameAsync(CustomRole role, string normalizedName,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task SetRoleNameAsync(CustomRole role, string roleName, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<IdentityResult> UpdateAsync(CustomRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Failed());
        }
    }
}