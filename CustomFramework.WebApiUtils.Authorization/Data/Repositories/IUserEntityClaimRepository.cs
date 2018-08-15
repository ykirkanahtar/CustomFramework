﻿using CustomFramework.Authorization.Enums;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserEntityClaimRepository : IRepository<UserEntityClaim, int>
    {
        Task<UserEntityClaim> GetByApplicationIdAndUserIdAndEntityAsync(int applicationId, int userId, string entity);
        Task<ICustomList<UserEntityClaim>> UserIsAuthorizedForEntityClaimAsync(int applicationId, int userId, string entity, Crud crud);
        Task<ICustomList<UserEntityClaim>> GetAllByEntityAsync(string entity);
        Task<ICustomList<UserEntityClaim>> GetAllByUserIdAsync(int userId);

    }
}