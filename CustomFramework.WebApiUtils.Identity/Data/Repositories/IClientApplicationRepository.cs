using System.Threading.Tasks;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Models;

namespace CustomFramework.WebApiUtils.Identity.Data.Repositories
{
    public interface IClientApplicationRepository : IRepository<ClientApplication, int>
    {
        Task<ClientApplication> GetByNameAsync(string name);
        Task<ClientApplication> GetByCodeAsync(string code);
        Task<ClientApplication> GetByCodeAndPasswordAsync(string code, string password);
        
    }
}