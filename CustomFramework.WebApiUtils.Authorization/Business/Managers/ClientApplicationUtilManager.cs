using AutoMapper;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class ClientApplicationUtilManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IClientApplicationUtilManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public ClientApplicationUtilManager(IUnitOfWorkAuthorization uow, ILogger<ClientApplicationUtilManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<ClientApplicationUtil> CreateAsync(ClientApplicationUtilRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<ClientApplicationUtil>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.ClientApplications.GetByIdAsync(request.ClientApplicationId)).CheckRecordIsExist(typeof(ClientApplication).Name);
                /***************************************************************/
                /***************************************************************/

                _uow.ClientApplicationUtils.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplicationUtil> UpdateAsync(int id, ClientApplicationUtilUpdateRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                _uow.ClientApplicationUtils.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.ClientApplicationUtils.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplicationUtil> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.ClientApplicationUtils.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId)
        {
            return CommonOperationAsync(async () => await _uow.ClientApplicationUtils.GetByClientApplicationIdAsync(clientApplicationId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}
