using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course, int>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Course> GetByCourseNoAsync(int courseNo)
        {
            return await Get(p => p.CourseNo == courseNo).IncludeMultiple(p => p.Teacher, p => p.StudentCourses).FirstOrDefaultAsync();
        }
        public async Task<ICustomList<Course>> GetAllByTeacherIdAsync(int teacherId)
        {
            return await GetAll(predicate: p => p.TeacherId == teacherId).IncludeMultiple(p => p.Teacher, p => p.StudentCourses).ToCustomList();
        }
        public async Task<ICustomList<Course>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.Teacher, p => p.StudentCourses).ToCustomList();
        }

    }
}