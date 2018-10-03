using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleClaimManager : IBusinessManager<RoleClaim, RoleClaimRequest, int>
    {
        Task<bool> RolesAreAuthorizedForClaimAsync(int applicationId, IList<Role> roles, int claimId);
        Task<ICustomList<Claim>> GetClaimsByRoleIdAsync(int roleId);
        Task<ICustomList<Role>> GetRolesByClaimIdAsync(int claimId);
    }
}