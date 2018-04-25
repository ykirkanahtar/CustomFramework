using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserClaimRepository : IRepository<UserClaim, int>
    {
        Task<UserClaim> GetByUserIdAndClaimIdAsync(int userId, int claimId);
        Task<ICustomList<Claim>> GetClaimsByUserIdAsync(int userId);
        Task<ICustomList<User>> GetUsersByClaimIdAsync(int claimId);
        Task<ICustomList<UserClaim>> UserIsAuthorizedForClaimAsync(int userId, int claimId);
    }
}