using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface IStudentCourseRepository : IRepository<StudentCourse, int>
    {
        Task<ICustomList<StudentCourse>> GetAllByStudentIdAsync(int studentId);
        Task<ICustomList<StudentCourse>> GetAllByCourseIdAsync(int courseId);

    }
}