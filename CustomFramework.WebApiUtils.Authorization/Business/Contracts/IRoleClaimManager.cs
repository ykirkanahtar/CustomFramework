using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleClaimManager : IBusinessManager<RoleClaim, RoleClaimRequest, int>
    {
        Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, int claimId);
        Task<CustomEntityList<Role>> GetRolesByClaimIdAsync(int claimId);
        Task<CustomEntityList<Claim>> GetClaimsByRoleIdAsync(int roleId);
    }
}