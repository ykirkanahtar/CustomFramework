using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClaimRepository : IRepository<Claim, int>
    {
        Task<Claim> GetByCustomClaimAsync(string customClaim);
        Task<ICustomList<Claim>> GetAllAsync(int pageIndex, int pageSize);
    }
}
