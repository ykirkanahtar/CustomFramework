using System.Threading.Tasks;
using CustomFramework.LogProvider.Models;

namespace CustomFramework.LogProvider.Business
{
    public interface ILogManager
    {
        Task<Log> CreateAsync(Log log);
    }
}