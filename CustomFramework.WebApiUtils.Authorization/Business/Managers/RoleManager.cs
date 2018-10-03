using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class RoleManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IRoleManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public RoleManager(IUnitOfWorkAuthorization uow, ILogger<RoleManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Role> CreateAsync(RoleRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<Role>(request);

                var tempResult = await _uow.Roles.GetByNameAsync(result.RoleName);
                tempResult.CheckUniqueValue(AuthorizationConstants.RoleName);

                _uow.Roles.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Role> UpdateAsync(int id, RoleRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                var tempResult = await _uow.Roles.GetByNameAsync(result.RoleName);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.RoleName);

                _uow.Roles.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.Roles.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Role> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Roles.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Role> GetByNameAsync(string name)
        {
            return CommonOperationAsync(async () => await _uow.Roles.GetByNameAsync(name), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Role>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Roles.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}
