using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Authorization.Models;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomFramework.WebApiUtils.Authorization.Data.DataInitializers
{
    public class UserDataInitializer : BaseDataInitializer
    {
        public UserDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task Seed()
        {
            var users = ConfigHelper.GetSection("Users");
            foreach (var section in users.GetChildren())
            {
                var userName = section.GetValue<string>("UserName");
                var email = section.GetValue<string>("Email");
                var password = section.GetValue<string>("Password");

                if (GetUsersByUserNameAsync(userName).Result.Count > 0) continue;

                var hashedPassword = password.HashPassword(out var salt, Convert.ToInt32(ConfigHelper.GetConfigurationValue("AppSettings:IterationCount")));

                var user = new User
                {
                    UserName = userName,
                    Email = email,
                    Password = hashedPassword
                };

                UnitOfWork.GetRepository<User, int>().Add(user);

                await UnitOfWork.SaveChangesAsync();

                await CreateUserUtilAsync(user.Id, salt);
            }
        }

        private async Task<IList<User>> GetUsersByUserNameAsync(string userName)
        {
            return await UnitOfWork.GetRepository<User, int>()
                .GetAll(predicate: p => p.UserName == userName).ToListAsync();
        }

        private async Task CreateUserUtilAsync(int userId, string salt)
        {
            var userUtil = new UserUtil()
            {
                UserId = userId,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<UserUtil, int>().Add(userUtil);

            await UnitOfWork.SaveChangesAsync();
        }

    }
}
