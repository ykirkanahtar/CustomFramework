using System.Net;
using CustomFramework.Data;
using CustomFramework.SampleWebApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data
{
    public interface IUnitOfWorkSampleWebApi : IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        ICurrentAccountRepository CurrentAccounts { get; }
    }
}