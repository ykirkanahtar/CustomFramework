namespace CustomFramework.SampleWebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + nameof(Customer))]
    public class CustomerController : BaseControllerWithAuthorizationAndUpdate<Customer, CustomerRequest, CustomerRequest, CustomerResponse, ICustomerManager, int>
    {

        public CustomerController(ICustomerManager customerManager, ILocalizationService localizationService, ILogger<CustomerController> logger, IMapper mapper)
        : base(customerManager, localizationService, logger, mapper)
        {

        }

        [Route('create')]
        [HttpPost]
        [Permission(nameof(Customer), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] CustomerRequest request)
        {
                return await BaseCreate(request);
        }

        	[Route('{id:int}/update')]
      [HttpPut]
      [Permission(nameof(Customer), Crud.Update)]
      public async Task<IActionResult> Update(int id, [FromBody] CustomerRequest request)
      {
            return await BaseUpdate(id, request);
      }


        [Route('delete/{id:int}')]
        [HttpDelete]
        [Permission(nameof(Customer), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route('get/id/{id:int}')]
        [HttpGet]
        [Permission(nameof(Customer), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

	[Route('get/customerNo/{customerNo}')]
                            [HttpGet]
                            [Permission(nameof(Customer), Crud.Select)]
                            public async Task<IActionResult> GetByCustomerNo(string customerNo)
                            {
                                var result = await Manager.GetByCustomerNoAsync(customerNo);
                                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<Customer, CustomerResponse>(result)));
                            }
	[Route('getall/currentAccounts/{currentAccounts:{int}}')]
                            [HttpGet]
                            [Permission(nameof(Customer), Crud.Select)]
                            public async Task<IActionResult> GetAllByCurrentAccounts(int currentAccounts)
                            {
                                var result = await Manager.GetAllByCurrentAccountsAsync(currentAccounts);
                                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                                    Mapper.Map<IList<Customer>, IList<CustomerResponse>>(result.ResultList), result.Count));
                            }
	[Route('getall')]
                    [HttpGet]
                    [Permission(nameof(Customer), Crud.Select)]
                    public async Task<IActionResult> GetAll()
                    {
                        var result = await Manager.GetAllAsync();
                        return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                            Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResponse>>(result.ResultList),result.Count));
                    }
	[Route('getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}')]
                    [HttpGet]
                    [Permission(nameof(Customer), Crud.Select)]
                    public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
                    {
                        var result = await Manager.GetAllAsync(pageIndex, pageSize);
                        return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                            Mapper.Map<IList<Customer>, IList<CustomerResponse>>(result.ResultList.ToList()), result.Count));
                    }

    }
}