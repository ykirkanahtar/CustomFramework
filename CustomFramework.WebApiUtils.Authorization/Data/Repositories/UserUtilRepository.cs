﻿using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class UserUtilRepository : BaseRepository<UserUtil, int>, IUserUtilRepository
    {
        public UserUtilRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserUtil> GetByUserIdAsync(int userId)
        {
            return await Get(p => p.UserId == userId).FirstOrDefaultAsync();
        }
    }
}