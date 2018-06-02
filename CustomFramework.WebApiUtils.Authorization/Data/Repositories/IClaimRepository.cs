using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClaimRepository : IRepository<Claim, int>
    {
        Task<Claim> GetByCustomClaimAsync(string customClaim);
        Task<ICustomList<Claim>> GetAllAsync(int pageIndex, int pageSize);
    }
}
