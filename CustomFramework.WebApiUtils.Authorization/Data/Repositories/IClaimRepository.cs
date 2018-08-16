using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClaimRepository : IRepository<Claim, int>
    {
        Task<Claim> GetByCustomClaimAsync(string customClaim);
        Task<ICustomList<Claim>> GetAllAsync(int pageIndex, int pageSize);
    }
}
