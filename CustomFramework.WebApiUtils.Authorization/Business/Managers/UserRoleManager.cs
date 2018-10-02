using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class UserRoleManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserRoleManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public UserRoleManager(IUnitOfWorkAuthorization uow, ILogger<UserRoleManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<UserRole> CreateAsync(UserRoleRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = new UserRole()
                {
                    UserId = request.UserId,
                    RoleId = request.RoleId,
                };

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.Roles.GetByIdAsync(result.RoleId)).CheckRecordIsExist(typeof(Role).Name);
                (await _uow.Users.GetByIdAsync(result.UserId)).CheckRecordIsExist(typeof(User).Name);
                /***************************************************************/
                /***************************************************************/

                var tempResult = await _uow.UserRoles.GetByUserIdAndRoleIdAsync(result.UserId, result.RoleId);
                tempResult.CheckUniqueValue(GetType().Name);

                _uow.UserRoles.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.UserRoles.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int userId, int roleId)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await _uow.UserRoles.GetByUserIdAndRoleIdAsync(userId, roleId);
                _uow.UserRoles.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserRole> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.UserRoles.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<User>> GetUsersByRoleIdAsync(int roleId)
        {
            return CommonOperationAsync(async () => await _uow.UserRoles.GetUsersByRoleIdAsync(roleId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<Role>> GetRolesByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () => await _uow.UserRoles.GetRolesByUserIdAsync(userId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
