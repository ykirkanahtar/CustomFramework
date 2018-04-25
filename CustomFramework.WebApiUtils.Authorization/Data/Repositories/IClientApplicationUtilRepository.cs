using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClientApplicationUtilRepository : IRepository<ClientApplicationUtil, int>
    {
        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}