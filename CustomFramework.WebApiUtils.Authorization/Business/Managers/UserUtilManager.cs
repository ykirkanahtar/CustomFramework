using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class UserUtilManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserUtilManager
    {
        public UserUtilManager(IUnitOfWork unitOfWork, ILogger<UserUtilManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) 
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<UserUtil> CreateAsync(UserUtilRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<UserUtil>(request);

                UnitOfWork.GetRepository<UserUtil, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserUtil> UpdateAsync(int id, UserUtilUpdateRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                UnitOfWork.GetRepository<UserUtil, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<UserUtil, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserUtil> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<UserUtil, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<UserUtil> GetByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<UserUtil, int>()
                    .GetAll(predicate: p => p.UserId == userId)
                    .ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }
}
