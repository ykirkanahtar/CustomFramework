﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CustomFramework.WebApiUtils.Authorization.Controllers
{
    public abstract class BaseControllerWithAuthorizationAndUpdate<TEntity, TCreateRequest, TUpdateRequest, TResponse, TManager, TKey>
        : BaseControllerWithAuthorization<TEntity, TCreateRequest, TResponse, TManager, TKey> 
        where TEntity : BaseModel<TKey>
        where TManager : IBusinessManager<TEntity, TCreateRequest, TKey>, IBusinessManagerUpdate<TEntity, TUpdateRequest, TKey>
    {

        protected BaseControllerWithAuthorizationAndUpdate(TManager manager, ILocalizationService localizationService, ILogger<Controller> logger, IMapper mapper)
        : base(manager, localizationService, logger, mapper)
        {

        }

        protected async Task<IActionResult> BaseUpdate(TKey id, [FromBody] TUpdateRequest request)
        {
            var result = await Manager.UpdateAsync(id, request);
            return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<TEntity, TResponse>(result)));
        }
    }
}