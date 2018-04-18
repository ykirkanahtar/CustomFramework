using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserManager : IBusinessManager
    {
        Task<User> CreateAsync(UserRequest request);
        Task<User> UpdateUserNameAsync(int id, string userName);
        Task<User> UpdatePasswordAsync(int id, string password);
        Task<User> UpdateEmailAsync(int id, string email);
        Task DeleteAsync(int id);
        Task<User> LoginAsync(string userName, string password);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<CustomEntityList<User>> GetAllAsync();
    }
}