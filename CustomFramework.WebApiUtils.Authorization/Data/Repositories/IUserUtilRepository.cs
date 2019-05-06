using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserUtilRepository : IRepository<UserUtil, int>
    {
        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}