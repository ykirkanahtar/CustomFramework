using System.Threading.Tasks;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface IMatchManager : IBusinessManager
    {
        Task<Match> CreateAsync(MatchRequest request);
        Task<Match> UpdateAsync(int id, MatchRequest request);
        Task DeleteAsync(int id);
        Task<Match> GetByIdAsync(int id);
        Task<CustomEntityList<Match>> GetAllAsync();
    }
}
