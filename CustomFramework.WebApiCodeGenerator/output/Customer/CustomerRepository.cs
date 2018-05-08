namespace CustomFramework.SampleWebApi.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {

        }

	public async Task<Customer> GetByCustomerNoAsync(string customerNo)
                        {
                            return await Get(p => p.CustomerNo == customerNo).IncludeMultiple(p=>p.CurrentAccounts).FirstOrDefaultAsync();
                        }
	public async Task<ICustomList<Customer>> GetAllByCurrentAccountsAsync(int currentAccounts)
                        {
                            return await GetAll(predicate: p => p.CurrentAccounts == currentAccounts).IncludeMultiple(p=>p.CurrentAccounts).ToCustomList();
                        }
	public async Task<ICustomList<Customer>> GetAllAsync()
                        {
                            return await base.GetAll().IncludeMultiple(p=>p.CurrentAccounts).ToCustomList();
                        }
	public async Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageSize)
                        {
                            return await (await GetAllWithPagingAsync(paging: new Paging(pageIndex, pageSize))).IncludeMultiple(p=>p.CurrentAccounts).ToCustomList();
                        }

    }
}