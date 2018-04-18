using System;
using System.Collections.Generic;
using CustomFramework.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.Data.Utils
{
    public class SeedDataUtil
    {
        public static void SeedTData<T, TKey>(ModelBuilder modelBuilder, IEnumerable<T> list) where T : BaseModel<TKey>
        {
            foreach (var item in list)
            {
                SetCommonFields<T, TKey>(item);
                modelBuilder.Entity<T>()
                    .HasData(item);
            }
        }

        public static void SetCommonFields<T, TKey>(T entity) where T : BaseModel<TKey>
        {
            entity.CreateDateTime = DateTime.Now;
            entity.Status = Status.Active;
        }

    }
}