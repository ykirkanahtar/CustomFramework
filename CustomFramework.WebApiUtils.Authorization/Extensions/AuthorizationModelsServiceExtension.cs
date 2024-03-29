﻿using CustomFramework.Authorization.Utils;
using CustomFramework.WebApiUtils.Authorization.Business.Contracts;
using CustomFramework.WebApiUtils.Authorization.Business.Managers;
using CustomFramework.WebApiUtils.Authorization.Contracts.Requests;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Handlers;
using CustomFramework.WebApiUtils.Authorization.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFramework.WebApiUtils.Authorization.Extensions
{
    public static class AuthorizationModelsServiceExtension
    {
        public static IServiceCollection AddAuthorizationModels(this IServiceCollection services)
        {
            services.AddScoped<DbContext, AuthorizationContext>();
            services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IToken, Token>();

            /*********Repositories*********/
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IClaimRepository, ClaimRepository>();
            services.AddTransient<IClientApplicationRepository, ClientApplicationRepository>();
            services.AddTransient<IClientApplicationUtilRepository, ClientApplicationUtilRepository>();
            services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();
            services.AddTransient<IRoleEntityClaimRepository, RoleEntityClaimRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserClaimRepository, UserClaimRepository>();
            services.AddTransient<IUserEntityClaimRepository, UserEntityClaimRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserUtilRepository, UserUtilRepository>();
            /*********Repositories*********/

            /**********Managers***********/
            services.AddTransient<IApplicationManager, ApplicationManager>();
            services.AddTransient<IApplicationUserManager, ApplicationUserManager>();
            services.AddTransient<IClaimManager, ClaimManager>();
            services.AddTransient<IClientApplicationManager, ClientApplicationManager>();
            services.AddTransient<IClientApplicationUtilManager, ClientApplicationUtilManager>();
            services.AddTransient<IRoleClaimManager, RoleClaimManager>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IRoleEntityClaimManager, RoleEntityClaimManager>();
            services.AddTransient<IUserClaimManager, UserClaimManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserEntityClaimManager, UserEntityClaimManager>();
            services.AddTransient<IUserRoleManager, UserRoleManager>();
            services.AddTransient<IUserUtilManager, UserUtilManager>();
            services.AddTransient<IPermissionManager, PermissionManager>();
            /**********Managers***********/

            /************Fluent Validation************/
            services.AddTransient<IValidator<ApplicationRequest>, ApplicationValidator>();
            services.AddTransient<IValidator<ClaimRequest>, ClaimValidator>();
            services.AddTransient<IValidator<ClientApplicationRequest>, ClientApplicationValidator>();
            services.AddTransient<IValidator<RoleRequest>, RoleValidator>();
            services.AddTransient<IValidator<RoleClaimRequest>, RoleClaimValidator>();
            services.AddTransient<IValidator<RoleEntityClaimRequest>, RoleEntityClaimValidator>();
            services.AddTransient<IValidator<UserRequest>, UserValidator>();
            services.AddTransient<IValidator<UserClaimRequest>, UserClaimValidator>();
            services.AddTransient<IValidator<UserEntityClaimRequest>, UserEntityClaimValidator>();
            services.AddTransient<IValidator<UserRoleRequest>, UserRoleValidator>();
            /************Fluent Validation************/

            return services;
        }
    }
}