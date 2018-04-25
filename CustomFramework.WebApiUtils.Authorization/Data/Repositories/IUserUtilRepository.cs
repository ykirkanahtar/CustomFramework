using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserUtilRepository : IRepository<UserUtil, int>
    {
        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}