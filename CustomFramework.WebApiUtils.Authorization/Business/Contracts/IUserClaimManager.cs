using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserClaimManager : IBusinessManager<UserClaim, UserClaimRequest, int>
    {
        Task<bool> UserIsAuthorizedForClaimAsync(int applicationId, int userId, int claimId);
        Task<ICustomList<Claim>> GetClaimsByUserIdAsync(int userId);
        Task<ICustomList<User>> GetUsersByClaimIdAsync(int claimId);
    }
}