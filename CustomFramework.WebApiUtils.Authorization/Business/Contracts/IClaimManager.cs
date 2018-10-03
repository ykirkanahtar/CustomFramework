using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClaimManager : IBusinessManager<Claim, ClaimRequest, int>
                                    , IBusinessManagerUpdate<Claim, ClaimRequest, int>
    {
        Task<Claim> GetByCustomClaimAsync(string customClaim);
        Task<ICustomList<Claim>> GetAllAsync(int pageIndex, int pageSize);
    }
}