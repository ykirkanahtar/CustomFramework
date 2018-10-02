using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Contracts;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class UserEntityClaimManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserEntityClaimManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public UserEntityClaimManager(IUnitOfWorkAuthorization uow, ILogger<UserEntityClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<UserEntityClaim> CreateAsync(UserEntityClaimRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<UserEntityClaim>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.Applications.GetByIdAsync(result.ApplicationId)).CheckRecordIsExist(typeof(Application).Name);
                (await _uow.Users.GetByIdAsync(result.UserId)).CheckRecordIsExist(typeof(User).Name);
                /***************************************************************/
                /***************************************************************/

                var tempResult = await _uow.UserEntityClaims.GetByApplicationIdAndUserIdAndEntityAsync(result.ApplicationId, result.UserId, result.Entity);
                tempResult.CheckUniqueValue(AuthorizationConstants.Entity);

                _uow.UserEntityClaims.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserEntityClaim> UpdateAsync(int id, EntityClaimRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                _uow.UserEntityClaims.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.UserEntityClaims.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserEntityClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.UserEntityClaims.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);

        }

        public Task<bool> UserIsAuthorizedForEntityClaimAsync(int applicationId, int userId, string entity, Crud crud)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await _uow.UserEntityClaims.UserIsAuthorizedForEntityClaimAsync(applicationId, userId, entity, crud);
                return result.Count > 0;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<UserEntityClaim>> GetAllByEntityAsync(string entity)
        {
            return CommonOperationAsync(async () => await _uow.UserEntityClaims.GetAllByEntityAsync(entity), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<UserEntityClaim>> GetAllByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () => await _uow.UserEntityClaims.GetAllByUserIdAsync(userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}
