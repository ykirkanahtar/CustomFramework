namespace CustomFramework.SampleWebApi.Business
{
    public interface ICustomerManager :  IBusinessManager<Customer, CustomerRequest, int>
        , IBusinessManagerUpdate<Customer, CustomerRequest, int>
    {
	Task<Customer> GetByCustomerNoAsync(string customerNo);
	Task<ICustomList<Customer>> GetAllByCurrentAccountsAsync(int currentAccounts);
	Task<ICustomList<Customer>> GetAllAsync();
	Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageCount);

    }
}