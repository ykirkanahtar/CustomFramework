using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IApplicationRepository : IRepository<Application, int>
    {
        Task<Application> GetByNameAsync(string name);
        Task<ICustomList<Application>> GetAllAsync();
    }
}
