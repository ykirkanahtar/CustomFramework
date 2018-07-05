using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser, int>
    {
        Task<ApplicationUser> GetByUserIdAndApplicationIdAsync(int userId, int applicationId);
        Task<ICustomList<User>> GetUsersByApplicationIdAsync(int applicationId);
        Task<ICustomList<Application>> GetApplicationsByUserIdAsync(int userId);
    }
}