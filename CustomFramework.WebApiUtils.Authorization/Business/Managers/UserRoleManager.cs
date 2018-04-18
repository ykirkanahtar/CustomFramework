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
    public class UserRoleManager : BaseBusinessManagerWithApiRequest<UserRoleManager, ApiRequest>, IUserRoleManager
    {

        public UserRoleManager(IUnitOfWork unitOfWork, ILogger<UserRoleManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<bool> AddUserToRoleAsync(UserRoleRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = new UserRole()
                {
                    UserId = request.UserId,
                    RoleId = request.RoleId,
                };

                /******************References Table Check Values****************/
                /***************************************************************/
                await BusinessUtil.GetByIntIdChecker<Role, IRepository<Role>>(result.RoleId, UnitOfWork.GetRepository<Role, int>());

                await BusinessUtil.GetByIntIdChecker<User, IRepository<User>>(result.UserId, UnitOfWork.GetRepository<User, int>());
                /***************************************************************/
                /***************************************************************/

                await UniqueCheckForUserAndRoleAsync(result);

                UnitOfWork.GetRepository<UserRole, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<bool> RemoveUserFromRoleAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<UserRole, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserRole> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<UserRole, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<User>> GetUsersByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<User>
                {
                    EntityList = await UnitOfWork.GetRepository<UserRole, int>().GetAll(out var count, predicate: p => p.RoleId == roleId).Select(p => p.User).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Role>> GetRolesByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<Role>
                {
                    EntityList = await UnitOfWork.GetRepository<UserRole, int>().GetAll(out var count, predicate: p => p.UserId == userId).Select(p => p.Role).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForUserAndRoleAsync(UserRole entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<UserRole>();
            predicate = predicate.And(p => p.RoleId == entity.RoleId);
            predicate = predicate.And(p => p.UserId == entity.UserId);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<UserRole, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, GetType().Name);
        }

        #endregion
    }
}
