using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserUtilRepository : IRepository<UserUtil, int>
    {
        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}