using System.Collections.Generic;
using CustomFramework.Data.Utils;
using CustomFramework.SampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.SampleWebApi.Data.Seeding
{
    public class SeedWebApiData
    {
        public SeedWebApiData()
        {
            CurrentAccounts = new List<CurrentAccount>();
            Customers = new List<Customer>();
        }

        public IList<Customer> Customers{ get; set; }
        public IList<CurrentAccount> CurrentAccounts { get; set; }

        public void SeedCustomerData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<Customer, int>(modelBuilder, Customers);
        }

        public void SeedCurrentAccountData(ModelBuilder modelBuilder)
        {
            SeedDataUtil.SeedTData<CurrentAccount, int>(modelBuilder, CurrentAccounts);
        }

        public void SeedAll(ModelBuilder modelBuilder)
        {
            SeedCustomerData(modelBuilder);
            SeedCurrentAccountData(modelBuilder);
        }
    }
}