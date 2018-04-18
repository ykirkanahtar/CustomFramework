using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Constants;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class ClaimManager : BaseBusinessManagerWithApiRequest<ClaimManager, ApiRequest>, IClaimManager
    {
        public ClaimManager(IUnitOfWork unitOfWork, ILogger<ClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) 
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<Claim> CreateAsync(ClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = AddToRepositoryAsync(request);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Claim AddToRepositoryAsync(ClaimRequest request)
        {
            var result = Mapper.Map<Claim>(request);

            UniqueCheckForCustomClaimAsync(result).Wait();

            UnitOfWork.GetRepository<Claim, int>().Add(result);

            return result;
        }

        public Task<Claim> UpdateAsync(int id, ClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await UpdateRepositoryAsync(id, request);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public async Task<Claim> UpdateRepositoryAsync(int id, ClaimRequest request)
        {
            var result = await GetByIdAsync(id);

            Mapper.Map(request, result);

            await UniqueCheckForCustomClaimAsync(result, id);

            UnitOfWork.GetRepository<Claim, int>().Update(result);

            return result;
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                await DeleteFromRepositoryAsync(id);
                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public async Task DeleteFromRepositoryAsync(int id)
        {
            var result = await GetByIdAsync(id);
            UnitOfWork.GetRepository<Claim, int>().Delete(result);
        }

        public Task<Claim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    var result = await GetFromRepoById(id);
                    return result;
                }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public async Task<Claim> GetFromRepoById(int id)
        {
            return await UnitOfWork.GetRepository<Claim, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task<Claim> GetByCustomClaimAsync(CustomClaim customClaim)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetAllFromRepoByCustomClaim(customClaim);
                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public async Task<List<Claim>> GetAllFromRepoByCustomClaim(CustomClaim customClaim)
        {
            return await UnitOfWork.GetRepository<Claim, int>().GetAll(predicate: p => p.CustomClaim == customClaim,
                skipTake: new SkipTake(0, WebApiUtilConstants.DefaultListCount)).ToListAsync();
        }

        public Task<CustomEntityList<Claim>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await GetAllFromRepo(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public async Task<CustomEntityList<Claim>> GetAllFromRepo()
        {
            return new CustomEntityList<Claim>
            {
                EntityList = await UnitOfWork.GetRepository<Claim, int>().GetAll(out var count)
                    .ToListAsync(),
                Count = count,
            };
        }

        #region Validations
        private async Task UniqueCheckForCustomClaimAsync(Claim entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<Claim>();
            predicate = predicate.And(p => p.CustomClaim == entity.CustomClaim);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<Claim, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, AuthorizationConstants.CustomClaim);
        }

        #endregion

    }
}
