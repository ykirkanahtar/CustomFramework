using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CustomFramework.Data;
using CustomFramework.Data.Models;
using CustomFramework.WebApiUtils.Enums;

namespace CustomFramework.WebApiUtils.Utils
{
    public static class BusinessUtil
    {
        public static void Execute<TEntity>(BusinessUtilMethod businessUtilMethod, TEntity result, string additionnalInfo)
        {
            switch (businessUtilMethod)
            {
                case BusinessUtilMethod.UniqueGenericListChecker:
                    result.UniqueGenericListChecker(additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckDuplicatationForUniqueValue:
                    result.CheckDuplicatationForUniqueValue(additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckRecordIsExist:
                    result.CheckRecordIsExist(additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckUniqueValue:
                    result.CheckUniqueValue(additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckNothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(businessUtilMethod.ToString());
            }
        }

        public static void UniqueGenericListChecker<T>(this T result, string additionalInfo)
        {
            result.CheckDuplicatationForUniqueValue(additionalInfo.RemoveManagerString());
            result.CheckRecordIsExist(additionalInfo.RemoveManagerString());
        }

        public static void CheckDuplicatationForUniqueValue<T>(this T result, string additionalInfo)
        {
            if (result.GetGenericTypeCount() <= 1) return;
            throw new DuplicateNameException(additionalInfo.RemoveManagerString());
        }

        public static void CheckRecordIsExist<T>(this T result, string additionalInfo)
        {
            if (!result.GenericTypeIsNullOrEmpty()) return;
            throw new KeyNotFoundException(additionalInfo.RemoveManagerString());
        }

        public static void CheckUniqueValue<TEntity>(this TEntity result, string additionalInfo)
        {
            if (!result.GenericTypeIsNullOrEmpty()) throw new DuplicateNameException(additionalInfo.RemoveManagerString());
        }

        public static void CheckUniqueValueForUpdate<TEntity, TKey>(this TEntity result, TKey id, string additionalInfo) where TEntity : BaseModel<TKey>
        {
            if (result.GenericTypeIsNullOrEmpty()) return;
            if (!result.Id.Equals(id))
                throw new DuplicateNameException(additionalInfo.RemoveManagerString());
        }

        public static void CheckUniqueValueForUpdate<TEntity, TKey>(this IList<TEntity> result, TKey id, string additionalInfo) where TEntity : BaseModel<TKey>
        {
            if (result.GenericTypeIsNullOrEmpty()) return;
            if (!result.Any(p => p.Id.Equals(id))) //eğer güncellenecek id'ye ait kayıt dışında da kayıt varsa 
                throw new DuplicateNameException(additionalInfo.RemoveManagerString());
        }

        public static void CheckSubFieldIsExistForDelete(this IEnumerable result, string additionalInfo)
        {
            if (result.GetEnumerableCount() == 0) return;
            throw new AccessViolationException(additionalInfo.RemoveManagerString());
        }

        public static bool GenericTypeIsNullOrEmpty<T>(this T value)
        {
            return value.GetGenericTypeCount() <= 0;
        }

        private static int GetEnumerableCount(this IEnumerable Enumerable)
        {
            return (from object Item in Enumerable select Item).Count();
        }

        private static int GetGenericTypeCount<T>(this T value)
        {
            //Eski kod. Sorun çıkmazsa silinebilir. 03.04.2019
            if (value == null) return 0;
            var pi = value.GetType().GetProperty("Count");
            if (pi != null)
            {
                var count = Convert.ToInt32(pi.GetValue(value));
                return count;
            }
            else
            {
                return 1;
            }
        }

        private static string RemoveManagerString(this string value)
        {
            const string removalString = "Manager";
            return value.Contains(removalString) ? value.Replace(removalString, string.Empty) : value;
        }
    }
}