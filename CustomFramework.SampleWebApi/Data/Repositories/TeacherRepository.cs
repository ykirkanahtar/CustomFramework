using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Teacher> GetByTeacherNoAsync(int teacherNo)
        {
            return await Get(p => p.TeacherNo == teacherNo).IncludeMultiple(p => p.Courses).FirstOrDefaultAsync();
        }
        public async Task<ICustomList<Teacher>> GetAllAsync()
        {
            return await GetAll().IncludeMultiple(p => p.Courses).ToCustomList();
        }

    }
}