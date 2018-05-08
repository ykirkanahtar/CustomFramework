using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Data;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Business
{
    public class CurrentAccountManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ICurrentAccountManager
    {
        private readonly IUnitOfWorkSampleWebApi _uow;

        public CurrentAccountManager(IUnitOfWorkSampleWebApi uow, ILogger<CurrentAccountManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<CurrentAccount> CreateAsync(CurrentAccountRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<CurrentAccount>(request);

                /******************Code is unique*********************/
                /*****************************************************/
                var tempResult = await _uow.CurrentAccounts.GetByCodeAsync(request.Code);

                tempResult.CheckUniqueValue(WebApiResourceConstants.CurrentAccountCode);
                /*****************************************************/
                /******************Code is unique*********************/


                /******************Name is unique*********************/
                /*****************************************************/
                tempResult = await _uow.CurrentAccounts.GetByNameAsync(request.Name);

                tempResult.CheckUniqueValue(WebApiResourceConstants.CurrentAccountName);
                /*****************************************************/
                /******************Name is unique*********************/
                _uow.CurrentAccounts.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<CurrentAccount> UpdateAsync(int id, CurrentAccountRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /******************Code is unique*********************/
                /*****************************************************/
                var tempResult = await _uow.CurrentAccounts.GetByCodeAsync(result.Code);

                tempResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.CurrentAccountCode);
                /*****************************************************/
                /******************Code is unique*********************/


                /******************Name is unique*********************/
                /*****************************************************/
                tempResult = await _uow.CurrentAccounts.GetByNameAsync(request.Name);

                tempResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.CurrentAccountName);
                /*****************************************************/
                /******************Name is unique*********************/

                _uow.CurrentAccounts.Update(result);

                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.CurrentAccounts.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<CurrentAccount> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.CurrentAccounts.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<CurrentAccount>> GetAllByCustomerIdAsync(int customerId)
        {
            return CommonOperationAsync(async () => await _uow.CurrentAccounts.GetAllByCustomerIdAsync(customerId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
