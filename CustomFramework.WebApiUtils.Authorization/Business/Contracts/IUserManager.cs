﻿using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Authorization.Request;
using CustomFramework.WebApiUtils.Business;

namespace CustomFramework.WebApiUtils.Authorization.Business.Contracts
{
    public interface IUserManager : IBusinessManager<User, UserRequest, int>
    {
        Task<User> UpdateUserNameAsync(int id, string userName);
        Task<User> UpdatePasswordAsync(int id, string password);
        Task<User> UpdateEmailAsync(int id, string email);
        Task<User> LoginAsync(string userName, string password);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task<ICustomList<User>> GetAllAsync();
    }
}