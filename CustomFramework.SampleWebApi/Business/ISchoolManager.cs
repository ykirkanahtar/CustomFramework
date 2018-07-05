using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ISchoolManager : IBusinessManager<School, SchoolRequest, int>
        , IBusinessManagerUpdate<School, SchoolRequest, int>
    {
        Task<School> GetByNameAsync(string name);
        Task<ICustomList<School>> GetAllAsync();
    }
}
