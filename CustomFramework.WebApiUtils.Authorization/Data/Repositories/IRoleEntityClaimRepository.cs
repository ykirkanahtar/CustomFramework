using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IRoleEntityClaimRepository : IRepository<RoleEntityClaim, int>
    {
        Task<RoleEntityClaim> GetByApplicationIdAndRoleIdAndEntityAsync(int applicationId, int roleId, string entity);
        Task<ICustomList<RoleEntityClaim>> RolesAreAuthorizedForEntityClaimAsync(int applicationId, IEnumerable<Role> roles, string entity, Crud crud);
        Task<ICustomList<RoleEntityClaim>> GetAllByEntityAsync(string entity);
        Task<ICustomList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId);

    }
}