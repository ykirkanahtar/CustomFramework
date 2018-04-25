﻿using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Constants;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Business.Managers
{
    public class ClaimManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IClaimManager
    {
        private readonly IUnitOfWorkAuthorization _uow;
        public ClaimManager(IUnitOfWorkAuthorization uow, ILogger<ClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Claim> CreateAsync(ClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Claim>(request);

                var tempResult = await _uow.Claims.GetByCustomClaimAsync(result.CustomClaim);
                tempResult.CheckUniqueValue(AuthorizationConstants.CustomClaim);

                _uow.Claims.Add(result);

                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Claim> UpdateAsync(int id, ClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                var tempResult = await _uow.Claims.GetByCustomClaimAsync(result.CustomClaim);
                tempResult.CheckUniqueValueForUpdate(id, AuthorizationConstants.CustomClaim);


                _uow.Claims.Update(result);
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                _uow.Claims.Delete(result);
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Claim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Claims.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Claim> GetByCustomClaimAsync(CustomClaim customClaim)
        {
            return CommonOperationAsync(async () => await _uow.Claims.GetByCustomClaimAsync(customClaim), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ICustomList<Claim>> GetAllAsync(int pageIndex, int pageSize)
        {
            return CommonOperationAsync(async () => await _uow.Claims.GetAllAsync(pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}
