using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserClaimManager : IBusinessManager
    {
        Task<bool> AddUserToClaimAsync(UserClaimRequest request);
        Task<bool> RemoveUserFromClaimAsync(int userClaimId);
        Task<UserClaim> GetByIdAsync(int id);
        Task<bool> UserIsAuthorizedForClaimAsync(int userId, int claimId);
        Task<CustomEntityList<User>> GetUsersByClaimIdAsync(int claimId);
        Task<CustomEntityList<Claim>> GetClaimsByUserIdAsync(int userId);
    }
}