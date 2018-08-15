using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course, int>
    {
        Task<Course> GetByCourseNoAsync(int courseNo);
        Task<ICustomList<Course>> GetAllByTeacherIdAsync(int teacherId);
        Task<ICustomList<Course>> GetAllAsync();

    }
}