using CustomFramework.Data.Repositories;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IClientApplicationUtilRepository : IRepository<ClientApplicationUtil, int>
    {
        Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId);
    }
}