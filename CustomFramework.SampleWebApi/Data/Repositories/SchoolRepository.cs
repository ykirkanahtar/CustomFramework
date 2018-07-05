using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class SchoolRepository : BaseRepository<School, int>, ISchoolRepository
    {
        public SchoolRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<School> GetByNameAsync(string name)
        {
            return await Get(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<School>> GetAllAsync()
        {
            return await GetAll().ToCustomList();
        }
    }
}
