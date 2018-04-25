using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IRoleClaimRepository : IRepository<RoleClaim, int>
    {
        Task<RoleClaim> GetByRoleIdAndClaimIdAsync(int roleId, int claimId);
        Task<ICustomList<Claim>> GetClaimsByRoleIdAsync(int roleId);
        Task<ICustomList<Role>> GetRolesByClaimIdAsync(int claimId);
        Task<ICustomList<RoleClaim>> RolesAreAuthorizedForClaimAsync(IEnumerable<Role> roles, int claimId);
    }
}