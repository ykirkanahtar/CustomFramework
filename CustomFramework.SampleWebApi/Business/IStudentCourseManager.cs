using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.SampleWebApi.Requests;

namespace CustomFramework.SampleWebApi.Business
{
    public interface IStudentCourseManager : IBusinessManager<StudentCourse, StudentCourseRequest, int>

    {
        Task<ICustomList<StudentCourse>> GetAllByStudentIdAsync(int studentId);
        Task<ICustomList<StudentCourse>> GetAllByCourseIdAsync(int courseId);

    }
}