using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
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
    public class StatManager : BaseBusinessManagerWithApiRequest<StatManager, ApiRequest>, IStatManager
    {
        public StatManager(IUnitOfWork unitOfWork, ILogger<StatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<Stat> CreateAsync(StatRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Stat>(request);

                await UniqueCheckForMatchIdAndTeamIdAndPlayerIdAsync(result);

                UnitOfWork.GetRepository<Stat, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Stat> UpdateAsync(int id, StatRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForMatchIdAndTeamIdAndPlayerIdAsync(result, id);

                UnitOfWork.GetRepository<Stat, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Stat, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Stat> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    return await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () =>
                {
                    return new CustomEntityList<Stat>
                    {
                        EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(out var count, predicate: p => p.MatchId == matchId, include: source => source.Include(p => p.Match).Include(p => p.Team).Include(p => p.Player)).ToListAsync(),
                        Count = count,
                    };
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () =>
                {
                    return new CustomEntityList<Stat>
                    {
                        EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(out var count, predicate: p => p.PlayerId == playerId, include: source => source.Include(p => p.Match).Include(p => p.Team).Include(p => p.Player)).ToListAsync(),
                        Count = count,
                    };
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllAsync()
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<Stat>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(out var count,  include: source => source.Include(p => p.Match).Include(p => p.Team).Include(p => p.Player)).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
        
        #region Validations
        private async Task UniqueCheckForMatchIdAndTeamIdAndPlayerIdAsync(Stat entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<Stat>();
            predicate = predicate.And(p => p.MatchId == entity.MatchId);
            predicate = predicate.And(p => p.TeamId == entity.TeamId);
            predicate = predicate.And(p => p.PlayerId == entity.PlayerId);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, WebApiResourceConstants.MatchIdAndTeamIdAndPlayerId);
        }

        #endregion

    }
}
