using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClientApplicationUtilRepository : IRepository<ClientApplicationUtil, int>
    {
        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}