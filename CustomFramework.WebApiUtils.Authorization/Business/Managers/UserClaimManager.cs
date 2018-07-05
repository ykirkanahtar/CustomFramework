using System.Reflection;
using System.Threading.Tasks;
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

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class UserClaimManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserClaimManager
    {
        private readonly IUnitOfWorkAuthorization _uow;
        public UserClaimManager(IUnitOfWorkAuthorization uow, ILogger<UserClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<UserClaim> CreateAsync(UserClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<UserClaim>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.Users.GetByIdAsync(result.UserId)).CheckRecordIsExist(typeof(User).Name);
                (await _uow.Claims.GetByIdAsync(result.ClaimId)).CheckRecordIsExist(typeof(Claim).Name);
                /***************************************************************/
                /***************************************************************/

                var tempResult = await _uow.UserClaims.GetByApplicationIdAndUserIdAndClaimIdAsync(result.ApplicationId, result.UserId, result.ClaimId);
                tempResult.CheckUniqueValue(GetType().Name);

                _uow.UserClaims.Add(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.UserClaims.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.UserClaims.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> UserIsAuthorizedForClaimAsync(int applicationId, int userId, int claimId)
        {
            return CommonOperationAsync(async () => (await _uow.UserClaims.UserIsAuthorizedForClaimAsync(applicationId, userId, claimId)).Count > 0, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<Claim>> GetClaimsByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () => await _uow.UserClaims.GetClaimsByUserIdAsync(userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<User>> GetUsersByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync(async () => await _uow.UserClaims.GetUsersByClaimIdAsync(claimId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
