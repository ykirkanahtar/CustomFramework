using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.SampleWebApi.Requests;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ITeacherManager : IBusinessManager<Teacher, TeacherRequest, int>
        , IBusinessManagerUpdate<Teacher, TeacherRequest, int>
    {
        Task<Teacher> GetByTeacherNoAsync(int teacherNo);
        Task<ICustomList<Teacher>> GetAllAsync();

    }
}