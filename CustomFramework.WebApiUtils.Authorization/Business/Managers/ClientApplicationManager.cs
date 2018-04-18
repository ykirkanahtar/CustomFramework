using System.Collections.Generic;
using System.Data;
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
    public class ClientApplicationManager : BaseBusinessManagerWithApiRequest<ClientApplicationManager, ApiRequest>, IClientApplicationManager
    {
        public ClientApplicationManager(IUnitOfWork unitOfWork, ILogger<ClientApplicationManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<ClientApplication> CreateAsync(ClientApplicationRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<ClientApplication>(request);

                await UniqueCheckForClientApplicationNameAsync(result);
                await UniqueCheckForClientApplicationCodeAsync(result);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(result.ClientApplicationPassword, salt,
                    AuthorizationUtilConstants.IterationCountForHashing);

                result.ClientApplicationPassword = hashPassword;

                UnitOfWork.GetRepository<ClientApplication, int>().Add(result);

                CreateClientApplicationUtil(result.Id, salt);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> UpdateClientApplicationAsync(int id, ClientApplicationUpdateRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForClientApplicationNameAsync(result, id);
                await UniqueCheckForClientApplicationCodeAsync(result, id);

                UnitOfWork.GetRepository<ClientApplication, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
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

                UnitOfWork.GetRepository<ClientApplication, int>().Update(result);

                await UpdateClientApplicationUtilAsync(id, salt);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {

                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<ClientApplication, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(predicate: p => p.Id == id)
                    .FirstOrDefaultAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplication> GetByClientApplicationCodeAsync(string code)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(predicate: p => p.ClientApplicationCode == code).ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
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
                    await GetClientApplicationUtilByClientApplicationIdAsync(clientApplication.Id);

                password = HashString.Hash(password, clientApplicationUtil.SpecialValue,
                    AuthorizationUtilConstants.IterationCountForHashing);

                var clientList = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(predicate: p => p.ClientApplicationCode == code && p.ClientApplicationPassword == password).ToListAsync();
                if (clientList.Count == 0) throw new AuthenticationException();
                if (clientList.Count > 1) throw new DuplicateNameException(DefaultResponseMessages.DuplicateRecordForUniqueValueError);

                return clientList[0];
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        #region Validations
        private async Task UniqueCheckForClientApplicationNameAsync(ClientApplication entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<ClientApplication>();
            predicate = predicate.And(p => p.ClientApplicationName == entity.ClientApplicationName);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, AuthorizationConstants.ClientApplicationName);
        }

        private async Task UniqueCheckForClientApplicationCodeAsync(ClientApplication entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<ClientApplication>();
            predicate = predicate.And(p => p.ClientApplicationCode == entity.ClientApplicationCode);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, AuthorizationConstants.ClientApplicationCode);
        }

        #endregion

        #region ClientApplicationUtil
        private async Task<ClientApplicationUtil> GetClientApplicationUtilByIdAsync(int id)
        {
            return await UnitOfWork.GetRepository<ClientApplicationUtil, int>().GetAll(predicate: p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        private async Task<ClientApplicationUtil> GetClientApplicationUtilByClientApplicationIdAsync(int clientApplicationId)
        {
            return await UnitOfWork.GetRepository<ClientApplicationUtil, int>()
                .GetAll(predicate: p => p.ClientApplicationId == clientApplicationId).FirstOrDefaultAsync();
        }

        private async Task UpdateClientApplicationUtilAsync(int id, string salt)
        {
            var clientApplicationUtil = await GetClientApplicationUtilByIdAsync(id);
            clientApplicationUtil.SpecialValue = salt;
            UnitOfWork.GetRepository<ClientApplicationUtil, int>().Update(clientApplicationUtil);
        }

        private void CreateClientApplicationUtil(int id, string salt)
        {
            var clientApplicationUtil = new ClientApplicationUtil()
            {
                ClientApplicationId = id,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<ClientApplicationUtil, int>().Add(clientApplicationUtil);
        }

        #endregion
    }

}
