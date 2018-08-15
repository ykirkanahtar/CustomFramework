using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>
    {
        Task<Role> GetByNameAsync(string name);

        Task<ICustomList<Role>> GetAllAsync();
    }
}