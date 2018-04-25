using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class ClaimRepository : BaseRepository<Claim, int>, IClaimRepository
    {
        public ClaimRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Claim> GetByCustomClaimAsync(CustomClaim customClaim)
        {
            return await Get(p => p.CustomClaim == customClaim).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Claim>> GetAllAsync(int pageIndex, int pageSize)
        {
            return await (await GetAllWithPagingAsync(paging: new Paging(pageIndex, pageSize))).ToCustomList();
        }
    }
}