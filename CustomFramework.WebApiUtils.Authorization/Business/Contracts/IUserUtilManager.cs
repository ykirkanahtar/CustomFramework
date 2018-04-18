using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserUtilManager : IBusinessManager
    {
        Task<UserUtil> CreateAsync(UserUtilRequest request);

        Task<UserUtil> UpdateSpecialValueAsync(int id, string specialValue);

        Task DeleteAsync(int id);

        Task<UserUtil> GetByIdAsync(int id);

        Task<UserUtil> GetByUserIdAsync(int userId);
    }
}