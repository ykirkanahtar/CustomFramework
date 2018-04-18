using System.Threading.Tasks;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ITeamManager : IBusinessManager
    {
        Task<Team> CreateAsync(TeamRequest request);
        Task<Team> UpdateAsync(int id, TeamRequest request);
        Task DeleteAsync(int id);
        Task<Team> GetByIdAsync(int id);
        Task<CustomEntityList<Team>> GetAllAsync();
    }
}
