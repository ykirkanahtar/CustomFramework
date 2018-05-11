using System.Reflection;
using System.Threading.Tasks;
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
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Business
{
    public class TeacherManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ITeacherManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public TeacherManager(IUnitOfWorkWebApi uow, ILogger<TeacherManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Teacher> CreateAsync(TeacherRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Teacher>(request);

                /******************TeacherNo is unique*********************/
                /*****************************************************/
                var teacherNoUniqueResult = await _uow.Teachers.GetByTeacherNoAsync(request.TeacherNo);

                teacherNoUniqueResult.CheckUniqueValue(WebApiResourceConstants.TeacherNo);
                /*****************************************************/
                /******************TeacherNo is unique*********************/


                _uow.Teachers.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Teacher> UpdateAsync(int id, TeacherRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /******************TeacherNo is unique*********************/
                /*****************************************************/
                var teacherNoUniqueResult = await _uow.Teachers.GetByTeacherNoAsync(request.TeacherNo);

                teacherNoUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.TeacherNo);
                /*****************************************************/
                /******************TeacherNo is unique*********************/


                _uow.Teachers.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }



        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Teachers.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Teachers.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Teacher> GetByTeacherNoAsync(int teacherNo)
        {
            return CommonOperationAsync(async () => await _uow.Teachers.GetByTeacherNoAsync(teacherNo), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
        public Task<ICustomList<Teacher>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Teachers.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

    }
}