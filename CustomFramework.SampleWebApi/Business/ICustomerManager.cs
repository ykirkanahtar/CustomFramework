using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.SampleWebApi.Business
{
    public interface ICustomerManager : IBusinessManager<Customer, CustomerRequest, int>
        , IBusinessManagerUpdate<Customer, CustomerRequest, int>
    {
        Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageSize);
    }
}
