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
    public class CourseManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ICourseManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public CourseManager(IUnitOfWorkWebApi uow, ILogger<CourseManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Course> CreateAsync(CourseRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Course>(request);

                /******************CourseNo is unique*********************/
                /*****************************************************/
                var courseNoUniqueResult = await _uow.Courses.GetByCourseNoAsync(request.CourseNo);

                courseNoUniqueResult.CheckUniqueValue(WebApiResourceConstants.CourseNo);
                /*****************************************************/
                /******************CourseNo is unique*********************/


                _uow.Courses.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Course> UpdateAsync(int id, CourseRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /******************CourseNo is unique*********************/
                /*****************************************************/
                var courseNoUniqueResult = await _uow.Courses.GetByCourseNoAsync(request.CourseNo);

                courseNoUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.CourseNo);
                /*****************************************************/
                /******************CourseNo is unique*********************/


                _uow.Courses.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }



        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Courses.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Course> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Courses.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Course> GetByCourseNoAsync(int courseNo)
        {
            return CommonOperationAsync(async () => await _uow.Courses.GetByCourseNoAsync(courseNo), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }
        public Task<ICustomList<Course>> GetAllByTeacherIdAsync(int teacherId)
        {
            return CommonOperationAsync(async () => await _uow.Courses.GetAllByTeacherIdAsync(teacherId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
        public Task<ICustomList<Course>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Courses.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

    }
}