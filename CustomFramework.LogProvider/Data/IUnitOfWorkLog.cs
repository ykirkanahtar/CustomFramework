using CustomFramework.Data;
using CustomFramework.LogProvider.Data.Repositories;

namespace CustomFramework.LogProvider.Data
{
    public interface IUnitOfWorkLog : IUnitOfWork
    {
        ILogRepository Logs { get; }
    }
}