using CustomFramework.Data.Repositories;
using CustomFramework.LogProvider.Models;

namespace CustomFramework.LogProvider.Data.Repositories
{
    public interface ILogRepository : IRepositoryNonUser<Log, long>
    {

    }
}