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
    public class ClientApplicationDataInitializer : BaseDataInitializer
    {
        public ClientApplicationDataInitializer(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task Seed()
        {
            var roles = ConfigHelper.GetSection("ClientApplication");
            foreach (var section in roles.GetChildren())
            {
                var name = section.GetValue<string>("Name");
                var code = section.GetValue<string>("Code");
                var password = section.GetValue<string>("Password");

                if (GetClientApplicationsByNameAsync(name).Result.Count > 0) continue;

                var hashedPassword = password.HashPassword(out var salt, Convert.ToInt32(ConfigHelper.GetConfigurationValue("AppSettings:IterationCount")));

                var clientApplication = new ClientApplication
                {
                    ClientApplicationName = name,
                    ClientApplicationCode = code,
                    ClientApplicationPassword = hashedPassword,
                };

                UnitOfWork.GetRepository<ClientApplication, int>().Add(clientApplication);

                await UnitOfWork.SaveChangesAsync();

                await CreateClientApplicationUtilAsync(clientApplication.Id, salt);
            }
        }

        private async Task<IList<ClientApplication>> GetClientApplicationsByNameAsync(string name)
        {
            return await UnitOfWork.GetRepository<ClientApplication, int>()
                .GetAll(predicate: p => p.ClientApplicationName == name).ToListAsync();
        }

        private async Task CreateClientApplicationUtilAsync(int clientApplicationId, string salt)
        {
            var clientApplicationUtil = new ClientApplicationUtil()
            {
                ClientApplicationId = clientApplicationId,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<ClientApplicationUtil, int>().Add(clientApplicationUtil);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
