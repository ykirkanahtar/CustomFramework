using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Student> GetByStudentNoAsync(int studentNo)
        {
            return await Get(p => p.StudentNo == studentNo).IncludeMultiple(p => p.StudentCourses).FirstOrDefaultAsync();
        }
        public async Task<ICustomList<Student>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.StudentCourses).ToCustomList();
        }
        public async Task<ICustomList<Student>> GetAllAsync(int pageIndex, int pageSize)
        {
            return await (await GetAllWithPagingAsync(paging: new Paging(pageIndex, pageSize))).IncludeMultiple(p => p.StudentCourses).ToCustomList();
        }

    }
}