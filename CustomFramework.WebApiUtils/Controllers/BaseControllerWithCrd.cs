﻿using AutoMapper;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Controllers
{
    public abstract class BaseControllerWithCrd<TEntity, TCreateRequest, TResponse, TManager, TKey> : BaseController
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>
    {
        protected readonly TManager Manager;

        protected BaseControllerWithCrd(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, TManager manager) 
            : base(localizationService, logger, mapper)
        {
            Manager = manager;
        }

        public async virtual Task<IActionResult> Create([FromBody] TCreateRequest request)
        {
            var result = await Manager.CreateAsync(request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }

        public async virtual Task<IActionResult> Delete(TKey id)
        {
            await Manager.DeleteAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(true));
        }

        public async virtual Task<IActionResult> GetById(TKey id)
        {
            var result = await Manager.GetByIdAsync(id);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}