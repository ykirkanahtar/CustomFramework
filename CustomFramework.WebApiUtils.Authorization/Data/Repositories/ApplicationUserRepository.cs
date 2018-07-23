﻿using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser, int>, IApplicationUserRepository
    {
        public ApplicationUserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ApplicationUser> GetByUserIdAndApplicationIdAsync(int applicationId, int userId)
        {
            return await Get(p => p.UserId == userId && p.ApplicationId == applicationId).FirstOrDefaultAsync();
        }

        public async Task<ICustomList<User>> GetUsersByApplicationIdAsync(int applicationId)
        {
            return await GetAll(p => p.ApplicationId == applicationId).IncludeMultiple(p => p.User).Select(p => p.User)
                .ToCustomList();
        }

        public async Task<ICustomList<Application>> GetApplicationsByUserIdAsync(int userId)
        {
            return await GetAll(p => p.UserId == userId).IncludeMultiple(p => p.Application).Select(p => p.Application)
                .ToCustomList();
        }
    }
}