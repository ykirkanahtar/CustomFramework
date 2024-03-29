﻿using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class UserManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IUserManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public UserManager(IUnitOfWorkAuthorization uow, ILogger<UserManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<User> CreateAsync(UserRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<User>(request);

                var tempResult = await _uow.Users.GetByUserNameAsync(result.UserName);
                tempResult.CheckUniqueValue(AuthorizationConstants.UserName);

                tempResult = await _uow.Users.GetByEmailAsync(result.Email);
                tempResult.CheckUniqueValue(AuthorizationConstants.Email);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(result.Password, salt,
                    AuthorizationUtilConstants.IterationCountForHashing);

                result.Password = hashPassword;

                _uow.Users.Add(result, GetLoggedInUserId());

                CreateUserUtil(result.Id, salt);

                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> UpdateNameSurnameAsync(int id, UserNameSurnameUpdate nameSurname)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                result.Name = nameSurname.Name;
                result.Surname = nameSurname.Surname;

                var tempResult = await _uow.Users.GetByUserNameAsync(result.UserName);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.UserName);

                _uow.Users.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }


        public Task<User> UpdateUserNameAsync(int id, string userName)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                result.UserName = userName;

                var tempResult = await _uow.Users.GetByUserNameAsync(result.UserName);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.UserName);

                _uow.Users.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> UpdatePasswordAsync(int id, string password)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                /** Hash password **/
                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(password, salt, AuthorizationUtilConstants.IterationCountForHashing);

                result.Password = hashPassword;

                _uow.Users.Update(result, GetLoggedInUserId());

                await UpdateUserUtilAsync(id, salt);

                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> UpdateEmailAsync(int id, string email)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                result.Email = email;

                var tempResult = await _uow.Users.GetByEmailAsync(result.Email);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.Email);

                _uow.Users.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.Users.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> LoginAsync(string email, string password)
        {
            return CommonOperationAsync(async () =>
            {
                var user = await _uow.Users.GetByEmailAsync(email);
                if (user == null) throw new AuthenticationException();

                /** Hash password **/
                var userUtil = await _uow.UserUtils.GetByUserIdAsync(user.Id);
                var hashed = HashString.Hash(password, userUtil.SpecialValue,
                    AuthorizationUtilConstants.IterationCountForHashing);
                password = hashed;
                /*******************/

                var result = await _uow.Users.GetByEmailAndPasswordAsync(email, password);
                if (result == null) throw new AuthenticationException();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<User> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetByUserNameAsync(userName), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetByEmailAsync(email), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<User>> GetAllByKeywordAsync(string keyword, int pageIndex, int pageSize)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetAllByKeywordAsync(keyword, pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<User>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Users.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<User>> GetAllAsync(int pageIndex, int pageSize)
        {
            return CommonOperationAsync(async () => await _uow.Users.GetAllAsync(pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<ICustomList<User>> GetAllLast10UserAsync()
        {
            return CommonOperationAsync(async () => await _uow.Users.GetAllLast10UserAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        #region UserUtil
        private async Task UpdateUserUtilAsync(int userId, string salt)
        {
            var userUtil = await _uow.UserUtils.GetByUserIdAsync(userId);
            userUtil.SpecialValue = salt;
            _uow.UserUtils.Update(userUtil, GetLoggedInUserId());
        }

        private void CreateUserUtil(int id, string salt)
        {
            var userUtil = new UserUtil
            {
                UserId = id,
                SpecialValue = salt,
            };
            _uow.UserUtils.Add(userUtil, GetLoggedInUserId());
        }
        #endregion
    }
}
