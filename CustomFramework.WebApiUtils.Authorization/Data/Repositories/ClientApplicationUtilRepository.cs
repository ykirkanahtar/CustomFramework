using CustomFramework.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class ClientApplicationUtilRepository : BaseRepository<ClientApplicationUtil, int>, IClientApplicationUtilRepository
    {
        public ClientApplicationUtilRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId)
        {
            return await Get(p => p.ClientApplicationId == clientApplicationId).FirstOrDefaultAsync();
        }
    }
}