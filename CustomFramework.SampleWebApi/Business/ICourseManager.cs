using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.SampleWebApi.Requests;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ICourseManager : IBusinessManager<Course, CourseRequest, int>
        , IBusinessManagerUpdate<Course, CourseRequest, int>
    {
        Task<Course> GetByCourseNoAsync(int courseNo);
        Task<ICustomList<Course>> GetAllByTeacherIdAsync(int teacherId);
        Task<ICustomList<Course>> GetAllAsync();

    }
}