using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class ApplicationRepository : BaseRepository<Application, int>, IApplicationRepository
    {
        public ApplicationRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Application> GetByNameAsync(string name)
        {
            return await Get(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<Application>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }
    }
}