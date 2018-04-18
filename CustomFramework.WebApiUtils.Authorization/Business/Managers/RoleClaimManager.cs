using System.Collections.Generic;
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
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class RoleClaimManager : BaseBusinessManagerWithApiRequest<RoleClaimManager, ApiRequest>, IRoleClaimManager
    {
        public RoleClaimManager(IUnitOfWork unitOfWork, ILogger<RoleClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<bool> AddRoleToClaimAsync(RoleClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<RoleClaim>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                await BusinessUtil.GetByIntIdChecker<Role, IRepository<Role>>(result.RoleId, UnitOfWork.GetRepository<Role, int>());

                await BusinessUtil.GetByIntIdChecker<Claim, IRepository<Claim>>(result.ClaimId, UnitOfWork.GetRepository<Claim, int>());
                /***************************************************************/
                /***************************************************************/

                await UniqueCheckForRoleClaimAsync(result);

                UnitOfWork.GetRepository<RoleClaim, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<bool> RemoveRoleFromClaimAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<RoleClaim, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<RoleClaim>();
                predicate = roles.Aggregate(predicate, (current, role) => current.Or(p => p.RoleId == role.Id));
                predicate = predicate.And(p => p.ClaimId == claimId);

                return (await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(predicate: predicate).Select(p => p).ToListAsync())
                       .Count > 0;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Claim>> GetClaimsByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<RoleClaim>();
                predicate = predicate.And(p => p.RoleId == roleId);

                return new CustomEntityList<Claim>
                {
                    EntityList = await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(out var count, predicate: p => p.RoleId == roleId).Select(p => p.Claim).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Role>> GetRolesByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<Role>
                {
                    EntityList = await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(out var count, predicate: p => p.ClaimId == claimId).Select(p => p.Role).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForRoleClaimAsync(RoleClaim entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<RoleClaim>();
            predicate = predicate.And(p => p.RoleId == entity.RoleId);
            predicate = predicate.And(p => p.ClaimId == entity.ClaimId);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<RoleClaim, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, GetType().Name);
        }

        #endregion

    }
}
