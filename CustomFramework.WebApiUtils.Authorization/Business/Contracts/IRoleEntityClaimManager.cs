using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleEntityClaimManager : IBusinessManager<RoleEntityClaim, RoleEntityClaimRequest, int>
                                             , IBusinessManagerUpdate<RoleEntityClaim, EntityClaimRequest, int>
    {
        Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, string entity, Crud crud);
        Task<CustomEntityList<RoleEntityClaim>> GetAllByEntityAsync(string entity);
        Task<CustomEntityList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId);
    }
}