using CustomFramework.Authorization.Enums;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserEntityClaimManager : IBusinessManager<UserEntityClaim, UserEntityClaimRequest, int>
                                                , IBusinessManagerUpdate<UserEntityClaim, EntityClaimRequest, int>
    {
        Task<bool> UserIsAuthorizedForEntityClaimAsync(int applicationId, int userId, string entity, Crud crud);
        Task<ICustomList<UserEntityClaim>> GetAllByEntityAsync(string entity);
        Task<ICustomList<UserEntityClaim>> GetAllByUserIdAsync(int userId);
    }
}