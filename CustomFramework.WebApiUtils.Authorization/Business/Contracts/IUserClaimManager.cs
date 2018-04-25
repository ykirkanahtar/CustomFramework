using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserClaimManager : IBusinessManager<UserClaim, UserClaimRequest, int>
    {
        Task<bool> UserIsAuthorizedForClaimAsync(int userId, int claimId);
        Task<ICustomList<Claim>> GetClaimsByUserIdAsync(int userId);
        Task<ICustomList<User>> GetUsersByClaimIdAsync(int claimId);
    }
}