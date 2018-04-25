using CustomFramework.Data;
using CustomFramework.SampleWebApi.Data.Repositories;

namespace CustomFramework.SampleWebApi.Data
{
    public class UnitOfWorkSampleWebApi : UnitOfWork<ApplicationContext>, IUnitOfWorkSampleWebApi 
    {
        public UnitOfWorkSampleWebApi(ApplicationContext context) : base(context)
        {
            Customers = new CustomerRepository(context);
            CurrentAccounts = new CurrentAccountRepository(context);
        }

        public ICustomerRepository Customers { get; }
        public ICurrentAccountRepository CurrentAccounts { get; }
    }
}