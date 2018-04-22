using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClientApplicationUtilManager : IBusinessManager<ClientApplicationUtil, ClientApplicationUtilRequest, int>
                                                    , IBusinessManagerUpdate<ClientApplicationUtil, ClientApplicationUtilUpdateRequest, int>
    {
        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}