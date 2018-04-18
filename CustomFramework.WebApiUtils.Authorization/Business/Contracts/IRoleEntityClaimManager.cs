using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IRoleEntityClaimManager : IBusinessManager
    {
        Task<RoleEntityClaim> CreateAsync(RoleEntityClaimRequest request);
        Task<RoleEntityClaim> UpdateAsync(int id, EntityClaimRequest request);
        Task DeleteAsync(int id);
        Task<RoleEntityClaim> GetByIdAsync(int id);
        Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, string entity, Crud crud);
        Task<CustomEntityList<RoleEntityClaim>> GetAllByEntityAsync(string entity);
        Task<CustomEntityList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId);
    }
}