using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Requests;
using CustomFramework.SampleWebApi.Responses;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + nameof(Customer))]
    public class CustomerController
        : BaseControllerWithAuthorizationAndUpdate<Customer, CustomerRequest, CustomerRequest, CustomerResponse, ICustomerManager, int>
    {
        public CustomerController(ICustomerManager customerManager, ILocalizationService localizationService, ILogger<CustomerController> logger, IMapper mapper)
        : base(customerManager, localizationService, logger, mapper)
        {

        }

        [Route("create")]
        [HttpPost]
        [Permission(nameof(Customer), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] CustomerRequest request)
        {
            return await BaseCreate(request);
        }

        [Route("{id}/update")]
        [HttpPut]
        [Permission(nameof(Customer), Crud.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerRequest request)
        {
            return await BaseUpdate(id, request);
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        [Permission(nameof(Customer), Crud.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return await BaseDelete(id);
        }

        [Route("get/id/{id}")]
        [HttpGet]
        [Permission(nameof(Customer), Crud.Select)]
        public async Task<IActionResult> GetById(int id)
        {
            return await BaseGetById(id);
        }

        [Route("getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}")]
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