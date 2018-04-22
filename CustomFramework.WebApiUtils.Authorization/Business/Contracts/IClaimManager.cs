using System.Threading.Tasks;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClaimManager : IBusinessManager<Claim, ClaimRequest, int>
                                    , IBusinessManagerUpdate<Claim, ClaimRequest, int>
    {
        Task<Claim> GetByCustomClaimAsync(CustomClaim customClaim);
        Task<CustomEntityList<Claim>> GetAllAsync();
    }
}