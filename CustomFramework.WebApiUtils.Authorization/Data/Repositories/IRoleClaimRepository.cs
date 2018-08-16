using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IRoleClaimRepository : IRepository<RoleClaim, int>
    {
        Task<RoleClaim> GetByApplicationIdAndRoleIdAndClaimIdAsync(int applicationId, int roleId, int claimId);
        Task<ICustomList<Claim>> GetClaimsByRoleIdAsync(int roleId);
        Task<ICustomList<Role>> GetRolesByClaimIdAsync(int claimId);
        Task<ICustomList<RoleClaim>> RolesAreAuthorizedForClaimAsync(int applicationId, IEnumerable<Role> roles, int claimId);
    }
}