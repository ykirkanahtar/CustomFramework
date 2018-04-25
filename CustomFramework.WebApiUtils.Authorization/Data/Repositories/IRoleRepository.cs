using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>
    {
        Task<Role> GetByNameAsync(string name);

        Task<ICustomList<Role>> GetAllAsync();
    }
}