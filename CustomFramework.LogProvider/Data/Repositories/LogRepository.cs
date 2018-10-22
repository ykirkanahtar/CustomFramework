using CustomFramework.Data.Repositories;
using CustomFramework.LogProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.LogProvider.Data.Repositories
{
    public class LogRepository : BaseRepositoryNonUser<Log, long>, ILogRepository
    {
        public LogRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}