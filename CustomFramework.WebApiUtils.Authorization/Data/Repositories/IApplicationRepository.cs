using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IApplicationRepository : IRepository<Application, int>
    {
        Task<Application> GetByNameAsync(string name);
        Task<ICustomList<Application>> GetAllAsync();
    }
}
