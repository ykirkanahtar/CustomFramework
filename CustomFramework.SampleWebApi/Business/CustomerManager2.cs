using System.Linq;
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
    public class CustomerManager2 : BaseBusinessManagerWithApiRequest<ApiRequest>, ICustomerManager2
    {
        private readonly ICurrentAccountManager2 _currentAccountManager;
        public CustomerManager2(ICurrentAccountManager2 currentAccountManager, IUnitOfWork unitOfWork, ILogger<CustomerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {
            _currentAccountManager = currentAccountManager;
        }

        public Task<Customer> CreateAsync(CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Customer>(request);

                UniqueCheckForCustomerNo(request.CustomerNo);

                AddToRepository(result);

                //***************Current account code block*******************
                var currentAccount = Mapper.Map<CurrentAccount>(request.CurrentAccount);
                currentAccount.CustomerId = result.Id;

                await _currentAccountManager.CheckCurrentAccount(currentAccount);

                _currentAccountManager.AddToRepository(currentAccount);
                //***************Current account code block*******************

                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Customer AddToRepository(Customer entity)
        {
            UnitOfWork.GetRepository<Customer, int>().Add(entity);
            return entity;
        }

        public Task<Customer> UpdateAsync(int id, CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                UniqueCheckForCustomerNo(request.CustomerNo);

                UpdateRepository(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Customer UpdateRepository(Customer entity)
        {
            UnitOfWork.GetRepository<Customer, int>().Update(entity);
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                DeleteFromRepository(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public void DeleteFromRepository(Customer entity)
        {
            UnitOfWork.GetRepository<Customer, int>().Delete(entity);
        }

        public void UniqueCheckForCustomerNo(string customerNo, int? id = null)
        {
            var predicate = PredicateBuilder.New<Customer>();
            predicate = predicate.And(p => p.CustomerNo == customerNo);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = UnitOfWork.GetRepository<Customer, int>().GetAll(predicate: predicate).ToList();

            BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CustomerNo);
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await GetFromRepoByIdAsync(id);
                }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
        public async Task<Customer> GetFromRepoByIdAsync(int id)
        {
            return await UnitOfWork.GetRepository<Customer, int>().GetAll(predicate: p => p.Id == id).IncludeMultiple(p => p.CurrentAccounts).FirstOrDefaultAsync();
        }

        public Task<CustomEntityList<Customer>> GetAllAsync()
        {
            return CommonOperationAsync(async () =>
            {
                return await GetAllFromRepoAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public async Task<CustomEntityList<Customer>> GetAllFromRepoAsync()
        {
            return new CustomEntityList<Customer>
            {
                EntityList = await UnitOfWork.GetRepository<Customer, int>().GetAll(out var count).IncludeMultiple(p => p.CurrentAccounts).ToListAsync(),
                Count = count,
            };
        }
    }
}
