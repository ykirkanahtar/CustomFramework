using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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