﻿using CustomFramework.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Authorization.Models;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public class ClientApplicationRepository : BaseRepository<ClientApplication, int>, IClientApplicationRepository
    {
        public ClientApplicationRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<ClientApplication> GetByCodeAndPasswordAsync(string code, string password)
        {
            return await Get(p => p.ClientApplicationCode == code && p.ClientApplicationPassword == password)
                .FirstOrDefaultAsync();
        }

        public async Task<ClientApplication> GetByCodeAsync(string code)
        {
            return await Get(p => p.ClientApplicationCode == code).FirstOrDefaultAsync();
        }

        public async Task<ClientApplication> GetByNameAsync(string name)
        {
            return await Get(p => p.ClientApplicationName == name).FirstOrDefaultAsync();
        }
    }
}