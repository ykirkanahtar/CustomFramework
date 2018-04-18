using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClaimManager : IBusinessManager
    {
        Task<Claim> CreateAsync(ClaimRequest request);
        Task<Claim> UpdateAsync(int id, ClaimRequest request);
        Task DeleteAsync(int id);
        Task<Claim> GetByIdAsync(int id);
        Task<Claim> GetByCustomClaimAsync(CustomClaim customClaim);
        Task<CustomEntityList<Claim>> GetAllAsync();
    }
}