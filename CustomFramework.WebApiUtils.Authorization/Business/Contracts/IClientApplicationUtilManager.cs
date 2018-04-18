using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClientApplicationUtilManager : IBusinessManager
    {
        Task<ClientApplicationUtil> CreateAsync(ClientApplicationUtilRequest request);

        Task<ClientApplicationUtil> UpdateSpecialValueAsync(int id, string specialValue);

        Task DeleteAsync(int id);

        Task<ClientApplicationUtil> GetByIdAsync(int id);

        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}