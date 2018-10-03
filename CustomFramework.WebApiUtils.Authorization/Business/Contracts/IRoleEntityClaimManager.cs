using CustomFramework.Authorization.Enums;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleEntityClaimManager : IBusinessManager<RoleEntityClaim, RoleEntityClaimRequest, int>
                                             , IBusinessManagerUpdate<RoleEntityClaim, EntityClaimRequest, int>
    {
        Task<bool> RolesAreAuthorizedForEntityClaimAsync(int applicationId, IEnumerable<Role> roles, string entity, Crud crud);
        Task<ICustomList<RoleEntityClaim>> GetAllByEntityAsync(string entity);
        Task<ICustomList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId);
    }
}