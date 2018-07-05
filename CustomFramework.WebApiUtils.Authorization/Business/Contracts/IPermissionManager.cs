using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Contracts;
using CustomFramework.WebApiUtils.Authorization.Handlers;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Constants;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IPermissionManager
    {
        Task<bool> HasPermission(HasPermissionRequest hasPermissionRequest);

    }
}
