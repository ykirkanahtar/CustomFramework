using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserEntityClaimManager : IBusinessManager<UserEntityClaim, UserEntityClaimRequest, int>
                                                , IBusinessManagerUpdate<UserEntityClaim, EntityClaimRequest, int>
    {
        Task<bool> UserIsAuthorizedForEntityClaimAsync(int userId, string entity, Crud crud);
        Task<CustomEntityList<UserEntityClaim>> GetAllByEntityAsync(string entity);
        Task<CustomEntityList<UserEntityClaim>> GetAllByUserIdAsync(int userId);
    }
}