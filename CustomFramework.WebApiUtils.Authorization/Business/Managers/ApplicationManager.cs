using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Requests;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class ApplicationManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IApplicationManager
    {
        private readonly IUnitOfWorkAuthorization _uow;

        public ApplicationManager(IUnitOfWorkAuthorization uow, ILogger<ApplicationManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Application> CreateAsync(ApplicationRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<Application>(request);

                var tempResult = await _uow.Applications.GetByNameAsync(result.Name);
                tempResult.CheckUniqueValue(AuthorizationConstants.CustomClaim);

                _uow.Applications.Add(result, GetLoggedInUserId());

                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Application> UpdateAsync(int id, ApplicationRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                var tempResult = await _uow.Applications.GetByNameAsync(result.Name);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.Name);


                _uow.Applications.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.Applications.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Application> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Applications.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Application> GetByNameAsync(string name)
        {
            return CommonOperationAsync(async () => await _uow.Applications.GetByNameAsync(name), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Application>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Applications.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
