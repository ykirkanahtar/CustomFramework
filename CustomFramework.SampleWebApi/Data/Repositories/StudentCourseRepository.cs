using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class StudentCourseRepository : BaseRepository<StudentCourse, int>, IStudentCourseRepository
    {
        public StudentCourseRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<ICustomList<StudentCourse>> GetAllByStudentIdAsync(int studentId)
        {
            return await GetAll(predicate: p => p.StudentId == studentId).IncludeMultiple(p => p.Student, p => p.Course).ToCustomList();
        }
        public async Task<ICustomList<StudentCourse>> GetAllByCourseIdAsync(int courseId)
        {
            return await GetAll(predicate: p => p.CourseId == courseId).IncludeMultiple(p => p.Student, p => p.Course).ToCustomList();
        }

    }
}