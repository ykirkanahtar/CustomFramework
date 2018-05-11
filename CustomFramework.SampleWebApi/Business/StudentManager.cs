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
    public class StudentManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IStudentManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public StudentManager(IUnitOfWorkWebApi uow, ILogger<StudentManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Student> CreateAsync(StudentRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Student>(request);

                /******************StudentNo is unique*********************/
                /*****************************************************/
                var studentNoUniqueResult = await _uow.Students.GetByStudentNoAsync(request.StudentNo);

                studentNoUniqueResult.CheckUniqueValue(WebApiResourceConstants.StudentNo);
                /*****************************************************/
                /******************StudentNo is unique*********************/


                _uow.Students.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Student> UpdateAsync(int id, StudentRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /******************StudentNo is unique*********************/
                /*****************************************************/
                var studentNoUniqueResult = await _uow.Students.GetByStudentNoAsync(request.StudentNo);

                studentNoUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.StudentNo);
                /*****************************************************/
                /******************StudentNo is unique*********************/


                _uow.Students.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }



        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Students.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Student> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Students.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Student> GetByStudentNoAsync(int studentNo)
        {
            return CommonOperationAsync(async () => await _uow.Students.GetByStudentNoAsync(studentNo), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
        public Task<ICustomList<Student>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Students.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
        public Task<ICustomList<Student>> GetAllAsync(int pageIndex, int pageSize)
        {
            return CommonOperationAsync(async () => await _uow.Students.GetAllAsync(pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

    }
}