using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserClaimRepository : IRepository<UserClaim, int>
    {
        Task<UserClaim> GetByApplicationIdAndUserIdAndClaimIdAsync(int applicationId, int userId, int claimId);
        Task<ICustomList<Claim>> GetClaimsByUserIdAsync(int userId);
        Task<ICustomList<User>> GetUsersByClaimIdAsync(int claimId);
        Task<ICustomList<UserClaim>> UserIsAuthorizedForClaimAsync(int applicationId, int userId, int claimId);
    }
}