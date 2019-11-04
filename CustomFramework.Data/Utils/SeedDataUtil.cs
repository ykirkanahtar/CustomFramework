using System;
using System.Collections.Generic;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Enums;
using CustomFramework.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.Data.Utils
{
    public static class SeedDataUtil
    {
        public static void SeedTData<T, TKey>(ModelBuilder modelBuilder, IEnumerable<T> list, int userId) where T : BaseModel<TKey>
        {
            foreach (var item in list)
            {
                SetCommonFields<T, TKey>(item, userId);
                modelBuilder.Entity<T>()
                    .HasData(item);
            }
        }

        public static void SetCommonFields<T, TKey>(T entity, int userId) where T : BaseModel<TKey>
        {
            entity.CreateDateTime = DateTime.Now;
            entity.CreateUserId = userId;
            entity.Status = Status.Active;
        }

    }
}