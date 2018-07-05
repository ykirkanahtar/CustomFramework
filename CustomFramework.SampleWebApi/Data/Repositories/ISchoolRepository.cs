using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface ISchoolRepository : IRepository<School, int>
    {
        Task<School> GetByNameAsync(string name);

        Task<ICustomList<School>> GetAllAsync();
    }
}
