using System.Collections.Generic;
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
    public class RoleClaimManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IRoleClaimManager
    {
        private readonly IUnitOfWorkAuthorization _uow;
        public RoleClaimManager(IUnitOfWorkAuthorization uow, ILogger<RoleClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<RoleClaim> CreateAsync(RoleClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<RoleClaim>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.Roles.GetByIdAsync(result.RoleId)).CheckRecordIsExist(typeof(Role).Name);
                (await _uow.Claims.GetByIdAsync(result.ClaimId)).CheckRecordIsExist(typeof(Claim).Name);
                /***************************************************************/
                /***************************************************************/

                var tempResult = await _uow.RoleClaims.GetByRoleIdAndClaimIdAsync(result.RoleId, result.ClaimId);
                tempResult.CheckUniqueValue(GetType().Name);

                _uow.RoleClaims.Add(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.RoleClaims.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.RoleClaims.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await _uow.RoleClaims.RolesAreAuthorizedForClaimAsync(roles, claimId);
                return result.Count > 0;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<Claim>> GetClaimsByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async() => await _uow.RoleClaims.GetClaimsByRoleIdAsync(roleId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<Role>> GetRolesByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync(async () => await _uow.RoleClaims.GetRolesByClaimIdAsync(claimId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
