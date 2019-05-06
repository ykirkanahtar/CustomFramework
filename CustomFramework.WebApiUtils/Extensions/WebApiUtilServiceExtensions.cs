﻿using CustomFramework.LogProvider.Extensions;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.WebApiUtils.Extensions
{
    public static class WebApiUtilServiceExtensions
    {
        public static IServiceCollection AddWebApiUtilServices(this IServiceCollection services)
        {
            services.AddTransient<IApiRequestAccessor, ApiRequestAccessor>();
            services.AddTransient<IApiRequest, ApiRequest>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors();

            return services;
        }
    }
}
