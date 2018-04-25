using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class UserUtilManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserUtilManager
    {
        private readonly IUnitOfWorkAuthorization _uow;
        public UserUtilManager(IUnitOfWorkAuthorization uow, ILogger<UserUtilManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<UserUtil> CreateAsync(UserUtilRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<UserUtil>(request);
                _uow.UserUtils.Add(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserUtil> UpdateAsync(int id, UserUtilUpdateRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);
                _uow.UserUtils.Update(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.UserUtils.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserUtil> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.UserUtils.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<UserUtil> GetByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () => await _uow.UserUtils.GetByUserIdAsync(userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}
