namespace CustomFramework.SampleWebApi.Business
{
    public class CustomerManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ICustomerManager
    {
        private readonly IUnitOfWorkSampleWebApi _uow;

        public CustomerManager(IUnitOfWorkSampleWebApi uow, ILogger<CustomerManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Customer> CreateAsync(CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Customer>(request);

                	/******************CustomerNo is unique*********************/
                /*****************************************************/
                var CustomerNoUniqueResult = await _uow.Customers.GetByCustomerNoAsync(request.CustomerNo);

                CustomerNoUniqueResult.CheckUniqueValue(WebApiResourceConstants.CustomerNo);
                /*****************************************************/
                /******************CustomerNo is unique*********************/


                _uow.Customers.Add(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

	  public Task<Customer> UpdateAsync(int id, CustomerRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                	/******************CustomerNo is unique*********************/
                /*****************************************************/
                var CustomerNoUniqueResult = await _uow.Customers.GetByCustomerNoAsync(request.CustomerNo);

                CustomerNoUniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.CustomerNo);
                /*****************************************************/
                /******************CustomerNo is unique*********************/


                _uow.Customers.Update(result);
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }



        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Customers.Delete(result);

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Customers.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

	public Task<Customer> GetByCustomerNoAsync(string customerNo)
                        {
            return CommonOperationAsync(async () => await _uow.Customers.GetByCustomerNoAsync(customerNo), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);                        
                        }
	public Task<ICustomList<Customer>> GetAllByCurrentAccountsAsync(int currentAccounts)
                        {
            return CommonOperationAsync(async () => await _uow.Customers.GetAllByCurrentAccountsAsync(currentAccounts), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
                        }
	public Task<ICustomList<Customer>> GetAllAsync()
                        {
                            return CommonOperationAsync(async () => await _uow.Customers.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
                        }
	public Task<ICustomList<Customer>> GetAllAsync(int pageIndex, int pageSize)
                        {
                            return CommonOperationAsync(async () => await _uow.Customers.GetAllAsync(pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
                        }

    }
}