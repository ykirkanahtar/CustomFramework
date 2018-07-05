using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Constants;
using CustomFramework.SampleWebApi.Data;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomFramework.SampleWebApi.Business
{
    public class SchoolManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ISchoolManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public SchoolManager(IUnitOfWorkWebApi uow, ILogger<SchoolManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<School> CreateAsync(SchoolRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<School>(request);

                _uow.Schools.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<School> UpdateAsync(int id, SchoolRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<School>(request);

                _uow.Schools.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });

        }
        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Schools.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });

        }
        public Task<ICustomList<School>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Schools.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<School> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Schools.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<School> GetByNameAsync(string name)
        {
            return CommonOperationAsync(async () => await _uow.Schools.GetByNameAsync(name), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

    }
}
