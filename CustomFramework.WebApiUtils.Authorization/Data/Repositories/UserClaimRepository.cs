using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class UserClaimRepository : BaseRepository<UserClaim, int>, IUserClaimRepository
    {
        public UserClaimRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserClaim> GetByUserIdAndClaimIdAsync(int userId, int claimId)
        {
            return await Get(p => p.UserId == userId && p.ClaimId == claimId).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Claim>> GetClaimsByUserIdAsync(int userId)
        {
            return await GetAll(p => p.UserId == userId).IncludeMultiple(p => p.Claim).Select(p => p.Claim)
                .ToCustomList();
        }

        public async Task<ICustomList<User>> GetUsersByClaimIdAsync(int claimId)
        {
            return await GetAll(p => p.ClaimId == claimId).IncludeMultiple(p => p.User).Select(p => p.User)
                .ToCustomList();
        }

        public async Task<ICustomList<UserClaim>> UserIsAuthorizedForClaimAsync(int userId, int claimId)
        {
            return await GetAll(p => p.UserId == userId && p.ClaimId == claimId).ToCustomList();
        }
    }
}