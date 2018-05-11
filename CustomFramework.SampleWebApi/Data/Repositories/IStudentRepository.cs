using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        Task<Student> GetByStudentNoAsync(int studentNo);
        Task<ICustomList<Student>> GetAllAsync();
        Task<ICustomList<Student>> GetAllAsync(int pageIndex, int pageCount);
    }
}