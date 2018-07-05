using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class ApplicationUserManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IApplicationUserManager
    {
        private readonly IUnitOfWorkAuthorization _uow;
        public ApplicationUserManager(IUnitOfWorkAuthorization uow, ILogger<ApplicationUserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<ApplicationUser> CreateAsync(ApplicationUserRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = new ApplicationUser
                {
                    UserId = request.UserId,
                    ApplicationId = request.ApplicationId,
                };

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.Roles.GetByIdAsync(result.ApplicationId)).CheckRecordIsExist(typeof(Application).Name);
                (await _uow.Users.GetByIdAsync(result.UserId)).CheckRecordIsExist(typeof(User).Name);
                /***************************************************************/
                /***************************************************************/

                var tempResult = await _uow.ApplicationUsers.GetByUserIdAndApplicationIdAsync(result.UserId, result.ApplicationId);
                tempResult.CheckUniqueValue(GetType().Name);

                _uow.ApplicationUsers.Add(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.ApplicationUsers.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ApplicationUser> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.ApplicationUsers.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ApplicationUser> GetByApplicationIdAndUserIdAsync(int applicationId, int userId)
        {
            return CommonOperationAsync(async () => await _uow.ApplicationUsers.GetByUserIdAndApplicationIdAsync(applicationId, userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<User>> GetUsersByApplicationIdAsync(int roleId)
        {
            return CommonOperationAsync(async () => await _uow.ApplicationUsers.GetUsersByApplicationIdAsync(roleId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<Application>> GetApplicationsByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () => await _uow.ApplicationUsers.GetApplicationsByUserIdAsync(userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
