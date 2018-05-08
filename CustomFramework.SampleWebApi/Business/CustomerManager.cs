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
    public class CustomerManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ICustomerManager
    {
        private readonly IUnitOfWorkSampleWebApi _uow;
        public CustomerManager(IUnitOfWorkSampleWebApi uow, ILogger<BaseBusinessManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Customer> CreateAsync(CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Customer>(request);

                /*******************No is unique**********************/
                var tempResult = await _uow.Customers.GetByCustomerNoAsync(result.CustomerNo);

                tempResult.CheckUniqueValue(WebApiResourceConstants.CustomerNo);
                /*****************************************************/


                _uow.Customers.Add(result);

                //***************Current account code block*******************
                var currentAccount = Mapper.Map<CurrentAccount>(request.CurrentAccount);
                currentAccount.CustomerId = result.Id;

                /******************Code is unique*********************/
                var tempResultCa = await _uow.CurrentAccounts.GetByCodeAsync(currentAccount.Code);

                tempResultCa.CheckUniqueValue(WebApiResourceConstants.CurrentAccountCode);
                /*****************************************************/

                /******************Name is unique*********************/
                tempResultCa = await _uow.CurrentAccounts.GetByNameAsync(currentAccount.Name);

                tempResultCa.CheckUniqueValue(WebApiResourceConstants.CurrentAccountName);
                /*****************************************************/

                _uow.CurrentAccounts.Add(currentAccount);
                //***************Current account code block*******************

                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Customer> UpdateAsync(int id, CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /*******************No is unique**********************/
                var tempResult = await _uow.Customers.GetByCustomerNoAsync(result.CustomerNo);

                tempResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.CustomerNo);
                /*****************************************************/

                _uow.Customers.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await _uow.Customers.GetByIdAsync(id);

                _uow.Customers.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Customers.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageSize)
        {
            return CommonOperationAsync(async () => await _uow.Customers.GetAllAsync(pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
