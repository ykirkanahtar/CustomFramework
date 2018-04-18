using System.Linq;
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
    public class ClientApplicationUtilManager : BaseBusinessManagerWithApiRequest<ClientApplicationUtilManager, ApiRequest>, IClientApplicationUtilManager
    {
        public ClientApplicationUtilManager(IUnitOfWork unitOfWork, ILogger<ClientApplicationUtilManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<ClientApplicationUtil> CreateAsync(ClientApplicationUtilRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<ClientApplicationUtil>(request);

                UnitOfWork.GetRepository<ClientApplicationUtil, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplicationUtil> UpdateSpecialValueAsync(int id, string specialValue)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                result.SpecialValue = specialValue;

                UnitOfWork.GetRepository<ClientApplicationUtil, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<ClientApplicationUtil, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplicationUtil> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<ClientApplicationUtil, int>().GetAll(p => p.Id == id)
                    .FirstOrDefaultAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplicationUtil> GetByClientApplicationIdAsync(int clientApplicationId)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<ClientApplicationUtil, int>()
                    .GetAll(predicate: p => p.ClientApplicationId == clientApplicationId)
                    .Select(p => p)
                    .ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
    }

}
