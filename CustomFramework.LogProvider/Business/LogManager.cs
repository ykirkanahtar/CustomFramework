using CustomFramework.LogProvider.Data;
using CustomFramework.LogProvider.Models;
using System.Threading.Tasks;

namespace CustomFramework.LogProvider.Business
{
    public class LogManager : ILogManager
    {
        private readonly IUnitOfWorkLog _uow;

        public LogManager(IUnitOfWorkLog uow)
        {
            _uow = uow;
        }

        public async Task<Log> CreateAsync(Log log)
        {
            _uow.Logs.Add(log);
            await _uow.SaveChangesAsync();
            return log;
        }
    }
}