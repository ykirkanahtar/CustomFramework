using System.Threading.Tasks;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface IPlayerManager : IBusinessManager
    {
        Task<Player> CreateAsync(PlayerRequest request);
        Task<Player> UpdateAsync(int id, PlayerRequest request);
        Task DeleteAsync(int id);
        Task<Player> GetByIdAsync(int id);
        Task<CustomEntityList<Player>> GetAllAsync();
    }
}