using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Business
{
    public class CustomerManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ICustomerManager
    {
        public CustomerManager(IUnitOfWork unitOfWork, ILogger<CustomerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<Customer> CreateAsync(CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Customer>(request);

                /*******************No is unique**********************/
                /*****************************************************/
                var predicate = PredicateBuilder.New<Customer>();
                predicate = predicate.And(p => p.CustomerNo == request.CustomerNo);

                var tempResult = await UnitOfWork.GetRepository<Customer, int>().GetAll(predicate: predicate).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CustomerNo);
                /*****************************************************/
                /*******************No is unique**********************/

                UnitOfWork.GetRepository<Customer, int>().Add(result);

                //***************Current account code block*******************

                var resultCa = Mapper.Map<CurrentAccount>(request.CurrentAccount);
                resultCa.CustomerId = result.Id;

                /******************Code is unique*********************/
                /*****************************************************/
                var predicateCa = PredicateBuilder.New<CurrentAccount>();
                predicateCa = predicateCa.And(p => p.Code == request.CurrentAccount.Code);

                var tempResultCa = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicateCa).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResultCa, WebApiResourceConstants.CurrentAccountCode);
                /*****************************************************/
                /******************Code is unique*********************/


                /******************Name is unique*********************/
                /*****************************************************/
                predicateCa = PredicateBuilder.New<CurrentAccount>();
                predicateCa = predicateCa.And(p => p.Name == request.Name);

                tempResultCa = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicateCa).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResultCa, WebApiResourceConstants.CurrentAccountName);
                /*****************************************************/
                /******************Name is unique*********************/

                UnitOfWork.GetRepository<CurrentAccount, int>().Add(resultCa);
                //***************Current account code block*******************

                await UnitOfWork.SaveChangesAsync();

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
                /*****************************************************/
                var predicate = PredicateBuilder.New<Customer>();
                predicate = predicate.And(p => p.CustomerNo == request.CustomerNo);
                predicate = predicate.And(p => p.Id != id);

                var tempResult = await UnitOfWork.GetRepository<Customer, int>().GetAll(predicate: predicate).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CustomerNo);
                /*****************************************************/
                /*******************No is unique**********************/

                UnitOfWork.GetRepository<Customer, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Customer, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await UnitOfWork.GetRepository<Customer, int>().GetAll(predicate: p => p.Id == id).IncludeMultiple(p => p.CurrentAccounts).FirstOrDefaultAsync();
                }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Customer>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Customer>
            {
                EntityList = await UnitOfWork.GetRepository<Customer, int>().GetAll(out var count).IncludeMultiple(p => p.CurrentAccounts).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
