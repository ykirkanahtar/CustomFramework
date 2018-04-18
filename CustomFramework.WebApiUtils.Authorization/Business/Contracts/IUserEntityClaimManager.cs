using System.Threading.Tasks;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserEntityClaimManager : IBusinessManager
    {
        Task<UserEntityClaim> CreateAsync(UserEntityClaimRequest request);
        Task<UserEntityClaim> UpdateAsync(int id, EntityClaimRequest request);
        Task DeleteAsync(int id);
        Task<UserEntityClaim> GetByIdAsync(int id);
        Task<bool> UserIsAuthorizedForEntityClaimAsync(int userId, string entity, Crud crud);
        Task<CustomEntityList<UserEntityClaim>> GetAllByEntityAsync(string entity);
        Task<CustomEntityList<UserEntityClaim>> GetAllByUserIdAsync(int userId);
    }
}