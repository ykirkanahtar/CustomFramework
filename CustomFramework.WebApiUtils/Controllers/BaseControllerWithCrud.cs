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
    public abstract class BaseControllerWithCrud<TEntity, TCreateRequest, TUpdateRequest, TResponse, TManager, TKey>
        : BaseControllerWithCrd<TEntity, TCreateRequest, TResponse, TManager, TKey>
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>, IBusinessManagerUpdate<TEntity, TUpdateRequest, TKey>
    {
        protected BaseControllerWithCrud(ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper, TManager manager)
            : base(localizationService, logger, mapper, manager)
        {

        }

        [Route("{id:int}/update")]
        [HttpPut]
        public async Task<IActionResult> Update(TKey id, [FromBody] TUpdateRequest request)
        {
            var result = await Manager.UpdateAsync(id, request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}