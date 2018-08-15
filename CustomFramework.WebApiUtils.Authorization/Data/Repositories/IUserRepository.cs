﻿using CustomFramework.Data.Contracts;
using CustomFramework.Data.Repositories;
using CustomFramework.WebApiUtils.Authorization.Models;
using System.Threading.Tasks;

namespace CustomFramework.WebApiUtils.Authorization.Data.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUserNameAndPasswordAsync(string userName, string password);
        Task<ICustomList<User>> GetAllAsync();
    }
}