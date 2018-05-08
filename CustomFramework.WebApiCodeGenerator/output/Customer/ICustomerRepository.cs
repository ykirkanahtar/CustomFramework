namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
	Task<Customer> GetByCustomerNoAsync(string customerNo);
	Task<ICustomList<Customer>> GetAllByCurrentAccountsAsync(int currentAccounts);
	Task<ICustomList<Customer>> GetAllAsync();
	Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageCount);

    }
}