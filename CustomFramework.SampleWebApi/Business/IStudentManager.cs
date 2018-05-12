using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.SampleWebApi.Requests;

namespace CustomFramework.SampleWebApi.Business
{
    public interface IStudentManager : IBusinessManager<Student, StudentRequest, int>
        , IBusinessManagerUpdate<Student, StudentRequest, int>
    {
        Task<Student> GetByStudentNoAsync(int studentNo);
        Task<ICustomList<Student>> GetAllAsync();
        Task<ICustomList<Student>> GetAllAsync(int pageIndex, int pageSize);
    }
}