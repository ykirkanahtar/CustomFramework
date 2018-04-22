using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data;
using CustomFramework.Data.Utils;
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
    public class UserManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserManager
    {
        public UserManager(IUnitOfWork unitOfWork, ILogger<UserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) 
            : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<User> CreateAsync(UserRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<User>(request);

                await UniqueCheckForUserNameAsync(result);

                await UniqueCheckForEmailAsync(result);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(result.Password, salt,
                    AuthorizationUtilConstants.IterationCountForHashing);

                result.Password = hashPassword;

                UnitOfWork.GetRepository<User, int>().Add(result);

                CreateUserUtil(result.Id, salt);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> UpdateUserNameAsync(int id, string userName)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                result.UserName = userName;

                await UniqueCheckForUserNameAsync(result, id);

                UnitOfWork.GetRepository<User, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> UpdatePasswordAsync(int id, string password)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                /** Hash password **/
                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(password, salt, AuthorizationUtilConstants.IterationCountForHashing);

                result.Password = hashPassword;

                UnitOfWork.GetRepository<User, int>().Update(result);

                await UpdateUserUtilAsync(id, salt);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> UpdateEmailAsync(int id, string email)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                result.Email = email;

                await UniqueCheckForEmailAsync(result, id);

                UnitOfWork.GetRepository<User, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<User, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> LoginAsync(string userName, string password)
        {
            return CommonOperationAsync(async () =>
            {
                var user = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: p => p.UserName == userName).FirstOrDefaultAsync();

                if (user == null) throw new AuthenticationException();

                /** Hash password **/
                var clientApplicationUtil = await UnitOfWork.GetRepository<UserUtil, int>().GetAll(predicate: p => p.UserId == user.Id).FirstOrDefaultAsync();
                var hashed = HashString.Hash(password, clientApplicationUtil.SpecialValue,
                    AuthorizationUtilConstants.IterationCountForHashing);
                password = hashed;
                /*******************/

                var result = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: p => p.UserName == userName && p.Password == password).Select(p => p).ToListAsync();

                if (result.Count == 0) throw new AuthenticationException();
                if (result.Count > 1) throw new DuplicateNameException(DefaultResponseMessages.DuplicateRecordForUniqueValueError);

                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: p => p.UserName == userName).ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: p => p.Email == email).ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<User>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<User>
            {
                EntityList = await UnitOfWork.GetRepository<User, int>().GetAll(out var count).Select(p => p).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForUserNameAsync(User entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<User>();
            predicate = predicate.And(p => p.UserName == entity.UserName);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, AuthorizationConstants.UserName);
        }

        private async Task UniqueCheckForEmailAsync(User entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<User>();
            predicate = predicate.And(p => p.Email == entity.Email);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<User, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, AuthorizationConstants.Email);
        }

        #endregion


        #region UserUtil
        private async Task<UserUtil> GetUserUtilByIdAsync(int id)
        {
            return await UnitOfWork.GetRepository<UserUtil, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
        }

        private async Task<UserUtil> GetUserUtilByUserIdAsync(int userId)
        {
            return await UnitOfWork.GetRepository<UserUtil, int>().GetAll(predicate: p => p.UserId == userId).FirstOrDefaultAsync();
        }

        private async Task UpdateUserUtilAsync(int id, string salt)
        {
            var clientApplicationUtil = await GetUserUtilByUserIdAsync(id);
            clientApplicationUtil.SpecialValue = salt;
            UnitOfWork.GetRepository<UserUtil, int>().Update(clientApplicationUtil);
        }

        private void CreateUserUtil(int id, string salt)
        {
            var clientApplicationUtil = new UserUtil
            {
                UserId = id,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<UserUtil, int>().Add(clientApplicationUtil);
        }

        #endregion
    }
}
