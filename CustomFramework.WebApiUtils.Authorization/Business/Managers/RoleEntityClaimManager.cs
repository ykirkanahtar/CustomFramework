using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
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
    public class RoleEntityClaimManager : BaseBusinessManagerWithApiRequest<RoleEntityClaimManager, ApiRequest>, IRoleEntityClaimManager
    {
        public RoleEntityClaimManager(IUnitOfWork unitOfWork, ILogger<RoleEntityClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<RoleEntityClaim> CreateAsync(RoleEntityClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<RoleEntityClaim>(request);

                await UniqueCheckForRoleNameAndEntityClaimAsync(result);

                UnitOfWork.GetRepository<RoleEntityClaim, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleEntityClaim> UpdateAsync(int id, EntityClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                UnitOfWork.GetRepository<RoleEntityClaim, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<RoleEntityClaim, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<RoleEntityClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<RoleEntityClaim, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> RolesAreAuthorizedForClaimAsync(IList<Role> roles, string entity, Crud crud)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<RoleEntityClaim>();

                predicate = roles.Aggregate(predicate, (current, role) => current.Or(p => p.RoleId == role.Id));

                predicate = predicate.And(p => p.Entity == entity);
                PredicateBuilderForCrud(ref predicate, crud);

                return (await UnitOfWork.GetRepository<RoleEntityClaim, int>().GetAll(predicate: predicate).ToListAsync())
                         .Count > 0;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);

        }

        public Task<CustomEntityList<RoleEntityClaim>> GetAllByEntityAsync(string entity)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<RoleEntityClaim>
                {
                    EntityList = await UnitOfWork.GetRepository<RoleEntityClaim, int>().GetAll(out var count, predicate: p => p.Entity == entity).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<RoleEntityClaim>> GetAllByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<RoleEntityClaim>
                {
                    EntityList = await UnitOfWork.GetRepository<RoleEntityClaim, int>().GetAll(out var count, predicate: p => p.RoleId == roleId).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForRoleNameAndEntityClaimAsync(RoleEntityClaim entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<RoleEntityClaim>();
            predicate = predicate.And(p => p.RoleId == entity.RoleId);
            predicate = predicate.And(p => p.Entity == entity.Entity);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<RoleEntityClaim, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, AuthorizationConstants.Entity);
        }

        #endregion

        private static void PredicateBuilderForCrud(ref ExpressionStarter<RoleEntityClaim> predicate, Crud crud)
        {
            switch (crud)
            {
                case Crud.Create:
                    predicate = predicate.And(p => p.CanCreate);
                    break;
                case Crud.Update:
                    predicate = predicate.And(p => p.CanUpdate);
                    break;
                case Crud.Delete:
                    predicate = predicate.And(p => p.CanDelete);
                    break;
                case Crud.Select:
                    predicate = predicate.And(p => p.CanSelect);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(crud), crud, null);
            }
        }
    }
}
