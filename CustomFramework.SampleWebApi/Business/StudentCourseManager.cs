using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Data;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Authorization.Business;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Utils;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Business
{
    public class StudentCourseManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IStudentCourseManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public StudentCourseManager(IUnitOfWorkWebApi uow, ILogger<StudentCourseManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<StudentCourse> CreateAsync(StudentCourseRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<StudentCourse>(request);

                

                _uow.StudentCourses.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }



        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.StudentCourses.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<StudentCourse> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.StudentCourses.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

	public Task<ICustomList<StudentCourse>> GetAllByStudentIdAsync(int studentId)
                        {
            return CommonOperationAsync(async () => await _uow.StudentCourses.GetAllByStudentIdAsync(studentId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
                        }
	public Task<ICustomList<StudentCourse>> GetAllByCourseIdAsync(int courseId)
                        {
            return CommonOperationAsync(async () => await _uow.StudentCourses.GetAllByCourseIdAsync(courseId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
                        }

    }
}