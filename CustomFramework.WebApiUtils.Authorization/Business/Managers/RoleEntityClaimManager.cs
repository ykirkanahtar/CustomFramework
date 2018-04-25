using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
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
    public class RoleEntityClaimManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IRoleEntityClaimManager
    {
        private readonly IUnitOfWorkAuthorization _uow;
        public RoleEntityClaimManager(IUnitOfWorkAuthorization uow, ILogger<RoleEntityClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<RoleEntityClaim> CreateAsync(RoleEntityClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<RoleEntityClaim>(request);

                var tempResult = await _uow.RoleEntityClaims.GetByRoleIdAndEntityAsync(result.RoleId, result.Entity);
                tempResult.CheckUniqueValue(AuthorizationConstants.Entity);

                _uow.RoleEntityClaims.Add(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleEntityClaim> UpdateAsync(int id, EntityClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                _uow.RoleEntityClaims.Update(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.RoleEntityClaims.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleEntityClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.RoleEntityClaims.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> RolesAreAuthorizedForEntityClaimAsync(IEnumerable<Role> roles, string entity, Crud crud)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await _uow.RoleEntityClaims.RolesAreAuthorizedForEntityClaimAsync(roles, entity, crud);
                return result.Count > 0;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<RoleEntityClaim>> GetAllByEntityAsync(string entity)
        {
            return CommonOperationAsync(async () => await _uow.RoleEntityClaims.GetAllByEntityAsync(entity), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async () => await _uow.RoleEntityClaims.GetAllByRoleIdAsync(roleId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
