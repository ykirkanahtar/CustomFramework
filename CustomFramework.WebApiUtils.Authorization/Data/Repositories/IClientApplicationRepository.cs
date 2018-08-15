using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClientApplicationRepository : IRepository<ClientApplication, int>
    {
        Task<ClientApplication> GetByNameAsync(string name);
        Task<ClientApplication> GetByCodeAsync(string code);
        Task<ClientApplication> GetByCodeAndPasswordAsync(string code, string password);
    }
}