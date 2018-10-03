using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClientApplicationUtilManager : IBusinessManager<ClientApplicationUtil, ClientApplicationUtilRequest, int>
                                                    , IBusinessManagerUpdate<ClientApplicationUtil, ClientApplicationUtilUpdateRequest, int>
    {
        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}