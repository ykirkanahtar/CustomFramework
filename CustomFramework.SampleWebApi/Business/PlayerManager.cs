using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Business
{
    public class PlayerManager : BaseBusinessManagerWithApiRequest<PlayerManager, ApiRequest>, IPlayerManager
    {
        public PlayerManager(IUnitOfWork unitOfWork, ILogger<PlayerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {
        }

        public Task<Player> CreateAsync(PlayerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Player>(request);

                UnitOfWork.GetRepository<Player, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> UpdateAsync(int id, PlayerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                UnitOfWork.GetRepository<Player, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Player, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await UnitOfWork.GetRepository<Player, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Player>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Player>
            {
                EntityList = await UnitOfWork.GetRepository<Player, int>().GetAll(out var count).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
