using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.SampleWebApi.ApplicationSettings;
using CustomFramework.SampleWebApi.Business;
using CustomFramework.SampleWebApi.Models;
using CustomFramework.SampleWebApi.Request;
using CustomFramework.SampleWebApi.Resources;
using CustomFramework.SampleWebApi.Response;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.SampleWebApi.Controllers
{
    [Route(ApiConstants.DefaultRoute + nameof(Customer))]
    public class CustomerController 
        : BaseControllerWithAuthorizationAndUpdate<Customer, CustomerRequest, CustomerRequest, CustomerResponse, ICustomerManager2, int>
    {
        public CustomerController(ICustomerManager2 customerManager, ILocalizationService localizationService, ILogger<CustomerController> logger, IMapper mapper)
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

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        //[Permission(nameof(Customer), Crud.Select)]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await Manager.GetAllAsync();

            return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                Mapper.Map<IList<Customer>, IList<CustomerResponse>>(result.EntityList), result.Count));
        }
    }
}