using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Constants;
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
    public class CurrentAccountManager2 : BaseBusinessManagerWithApiRequest<ApiRequest>, ICurrentAccountManager, ICurrentAccountManager2
    {
        public CurrentAccountManager2(IUnitOfWork unitOfWork, ILogger<CurrentAccountManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<CurrentAccount> CreateAsync(CurrentAccountRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<CurrentAccount>(request);

                await CheckCurrentAccount(result);

                AddToRepository(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public CurrentAccount AddToRepository(CurrentAccount entity)
        {
            UnitOfWork.GetRepository<CurrentAccount, int>().Add(entity);
            return entity;
        }

        public Task<CurrentAccount> UpdateAsync(int id, CurrentAccountRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await CheckCurrentAccount(result);

                UpdateRepository(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public CurrentAccount UpdateRepository(CurrentAccount entity)
        {
            UnitOfWork.GetRepository<CurrentAccount, int>().Update(entity);
            return entity;
        }

        public async Task UniqueCheckForCurrentAccountcode(string currentAccountCode, int? id = null)
        {
            var predicate = PredicateBuilder.New<CurrentAccount>();
            predicate = predicate.And(p => p.Code == currentAccountCode);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CurrentAccountCode);

        }

        public async Task UniqueCheckForCurrentAccountName(string currentAccountName, int? id = null)
        {
            var predicate = PredicateBuilder.New<CurrentAccount>();
            predicate = predicate.And(p => p.Name == currentAccountName);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CurrentAccountName);
        }

        public async Task CheckCurrentAccount(CurrentAccount currentAccount)
        {
            await UniqueCheckForCurrentAccountcode(currentAccount.Code);
            await UniqueCheckForCurrentAccountName(currentAccount.Name);
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

        public void DeleteFromRepository(CurrentAccount entity)
        {
            UnitOfWork.GetRepository<CurrentAccount, int>().Delete(entity);
        }

        public Task<CurrentAccount> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await GetFromRepoById(id);
                }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public async Task<CurrentAccount> GetFromRepoById(int id)
        {
            return await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: p => p.Id == id).IncludeMultiple(p => p.Customer)
            .FirstOrDefaultAsync();
        }

        public Task<CustomEntityList<CurrentAccount>> GetAllAsync()
        {
            return CommonOperationAsync(async () =>
            {
                return await GetAllFromRepo();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public async Task<CustomEntityList<CurrentAccount>> GetAllFromRepo()
        {
            return new CustomEntityList<CurrentAccount>
            {
                EntityList = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(out var count).IncludeMultiple(p => p.Customer).ToListAsync(),
                Count = count,
            };
        }

    }
}
