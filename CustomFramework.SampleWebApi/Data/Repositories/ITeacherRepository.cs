using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface ITeacherRepository : IBaseRepository<Teacher, int>
    {
        Task<Teacher> GetByTeacherNoAsync(int teacherNo);
        Task<ICustomList<Teacher>> GetAllAsync();

    }
}