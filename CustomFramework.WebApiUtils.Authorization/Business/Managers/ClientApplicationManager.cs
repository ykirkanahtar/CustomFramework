using AutoMapper;
using CustomFramework.Authorization;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Authentication;
using System.Threading.Tasks;
using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Contracts;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class ClientApplicationManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IClientApplicationManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public ClientApplicationManager(IUnitOfWorkAuthorization uow, ILogger<ClientApplicationManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<ClientApplication> CreateAsync(ClientApplicationRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<ClientApplication>(request);

                var tempResult = await _uow.ClientApplications.GetByNameAsync(result.ClientApplicationName);
                tempResult.CheckUniqueValue(AuthorizationConstants.ClientApplicationName);

                tempResult = await _uow.ClientApplications.GetByCodeAsync(result.ClientApplicationCode);
                tempResult.CheckUniqueValue(AuthorizationConstants.ClientApplicationCode);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(result.ClientApplicationPassword, salt,
                    AuthorizationUtilConstants.IterationCountForHashing);

                result.ClientApplicationPassword = hashPassword;

                _uow.ClientApplications.Add(result, GetLoggedInUserId());

                CreateClientApplicationUtil(result.Id, salt);

                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> UpdateAsync(int id, ClientApplicationUpdateRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                var tempResult = await _uow.ClientApplications.GetByNameAsync(result.ClientApplicationName);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.ClientApplicationName);

                tempResult = await _uow.ClientApplications.GetByCodeAsync(result.ClientApplicationCode);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.ClientApplicationCode);

                _uow.ClientApplications.Update(result, GetLoggedInUserId());

                await _uow.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> UpdateClientApplicationPasswordAsync(int id, string clientApplicationPassword)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(clientApplicationPassword, salt,
                    AuthorizationUtilConstants.IterationCountForHashing);

                result.ClientApplicationPassword = hashPassword;

                _uow.ClientApplications.Update(result, GetLoggedInUserId());

                await UpdateClientApplicationUtilAsync(id, salt);

                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.ClientApplications.Delete(result, GetLoggedInUserId());

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.ClientApplications.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplication> GetByClientApplicationCodeAsync(string code)
        {
            return CommonOperationAsync(async () => await _uow.ClientApplications.GetByCodeAsync(code), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplication> LoginAsync(string code, string password)
        {
            return CommonOperationAsync(async () =>
            {
                ClientApplication clientApplication;
                try
                {
                    clientApplication = await GetByClientApplicationCodeAsync(code);
                }
                catch (KeyNotFoundException) //Eğer code sistemde yoksa, kayıt bulunamadı yerine authentication hatası fırlatması için try - catch kullanılıyor
                {
                    throw new AuthenticationException();
                }

                var clientApplicationUtil =
                    await _uow.ClientApplicationUtils.GetByClientApplicationIdAsync(clientApplication.Id);

                password = HashString.Hash(password, clientApplicationUtil.SpecialValue,
                    AuthorizationUtilConstants.IterationCountForHashing);

                var client = await _uow.ClientApplications.GetByCodeAndPasswordAsync(code, password);
                if (client == null) throw new AuthenticationException();

                return client;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        #region ClientApplicationUtil

        private async Task UpdateClientApplicationUtilAsync(int clientApplicationId, string salt)
        {
            var clientApplicationUtil = await _uow.ClientApplicationUtils.GetByClientApplicationIdAsync(clientApplicationId);
            clientApplicationUtil.SpecialValue = salt;
            _uow.ClientApplicationUtils.Update(clientApplicationUtil, GetLoggedInUserId());
        }

        private void CreateClientApplicationUtil(int id, string salt)
        {
            var clientApplicationUtil = new ClientApplicationUtil()
            {
                ClientApplicationId = id,
                SpecialValue = salt,
            };

            _uow.ClientApplicationUtils.Add(clientApplicationUtil, GetLoggedInUserId());
        }

        #endregion
    }

}
