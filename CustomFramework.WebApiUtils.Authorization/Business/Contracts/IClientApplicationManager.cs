using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IClientApplicationManager : IBusinessManager
    {
        Task<ClientApplication> CreateAsync(ClientApplicationRequest request);

        Task<ClientApplication> UpdateClientApplicationAsync(int id, ClientApplicationUpdateRequest request);

        Task<ClientApplication> UpdateClientApplicationPasswordAsync(int id, string clientApplicationPassword);

        Task DeleteAsync(int id);

        Task<ClientApplication> GetByIdAsync(int id);

        Task<ClientApplication> GetByClientApplicationCodeAsync(string code);

        Task<ClientApplication> LoginAsync(string code, string password);
    }
}