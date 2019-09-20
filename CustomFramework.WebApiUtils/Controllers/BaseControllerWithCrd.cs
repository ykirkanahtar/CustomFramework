using System;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Contracts.Resources;
using CustomFramework.WebApiUtils.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Controllers
{
    public abstract class BaseControllerWithCrd<TEntity, TCreateRequest, TResponse, TManager, TKey> : BaseController
    where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>
    {
        protected readonly TManager Manager;

        protected BaseControllerWithCrd(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, TManager manager) : base(localizationService, logger, mapper)
        {
            Manager = manager;
        }

        public async virtual Task<IActionResult> Create([FromBody] TCreateRequest request)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException(ModelState.ModelStateToString(LocalizationService));
                
            var result = await (CommonOperationAsync<TEntity>(async () =>
            {
                return await Manager.CreateAsync(request);
            }));
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }

        public async virtual Task<IActionResult> Delete(TKey id)
        {
            await Manager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        public async virtual Task<IActionResult> GetById(TKey id)
        {
            var result = await (CommonOperationAsync<TEntity>(async () =>
            {
                return await Manager.GetByIdAsync(id);
            }));
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}