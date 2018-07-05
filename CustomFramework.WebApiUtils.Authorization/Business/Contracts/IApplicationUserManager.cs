using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IApplicationUserManager : IBusinessManager<ApplicationUser, ApplicationUserRequest, int>
    {
        Task<ApplicationUser> GetByApplicationIdAndUserIdAsync(int applicationId, int userId);
        Task<ICustomList<User>> GetUsersByApplicationIdAsync(int applicationId);
        Task<ICustomList<Application>> GetApplicationsByUserIdAsync(int userId);
    }
}