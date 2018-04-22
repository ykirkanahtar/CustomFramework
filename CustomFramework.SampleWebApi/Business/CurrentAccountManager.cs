using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
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
    public class CurrentAccountManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ICurrentAccountManager
    {
        public CurrentAccountManager(IUnitOfWork unitOfWork, ILogger<CurrentAccountManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<CurrentAccount> CreateAsync(CurrentAccountRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<CurrentAccount>(request);

                /******************Code is unique*********************/
                /*****************************************************/
                var predicate = PredicateBuilder.New<CurrentAccount>();
                predicate = predicate.And(p => p.Code == request.Code);

                var tempResult = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicate).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CurrentAccountCode);
                /*****************************************************/
                /******************Code is unique*********************/


                /******************Name is unique*********************/
                /*****************************************************/
                predicate = PredicateBuilder.New<CurrentAccount>();
                predicate = predicate.And(p => p.Name == request.Name);

                tempResult = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicate).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CurrentAccountName);
                /*****************************************************/
                /******************Name is unique*********************/

                UnitOfWork.GetRepository<CurrentAccount, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

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
                var predicate = PredicateBuilder.New<CurrentAccount>();
                predicate = predicate.And(p => p.Code == request.Code);
                predicate = predicate.And(p => p.Id != id);

                var tempResult = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicate).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CurrentAccountCode);
                /*****************************************************/
                /******************Code is unique*********************/


                /******************Name is unique*********************/
                /*****************************************************/
                predicate = PredicateBuilder.New<CurrentAccount>();
                predicate = predicate.And(p => p.Name == request.Name);
                predicate = predicate.And(p => p.Id != id);

                tempResult = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: predicate).ToListAsync();

                BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.CurrentAccountName);
                /*****************************************************/
                /******************Name is unique*********************/

                UnitOfWork.GetRepository<CurrentAccount, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<CurrentAccount, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<CurrentAccount> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(predicate: p => p.Id == id
                                                                                        , include: source => source.Include(p => p.Customer)
                                                                                        ).FirstOrDefaultAsync();
                }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<CurrentAccount>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<CurrentAccount>
            {
                EntityList = await UnitOfWork.GetRepository<CurrentAccount, int>().GetAll(out var count
                                                                                        , include: source => source.Include(p => p.Customer)
                                                                                         ).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
