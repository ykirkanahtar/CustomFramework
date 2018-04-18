using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.WebApiUtils.Enums;
using Microsoft.EntityFrameworkCore;

namespace CustomFramework.WebApiUtils.Utils
{
    public static class BusinessUtil
    {
        public static void Execute<T>(BusinessUtilMethod businessUtilMethod, T result, string additionnalInfo, bool critical = false)
        {
            switch (businessUtilMethod)
            {
                case BusinessUtilMethod.UniqueGenericListChecker:
                    UniqueGenericListChecker(result, additionnalInfo, critical);
                    break;
                case BusinessUtilMethod.CheckDuplicatationForUniqueValue:
                    CheckDuplicatationForUniqueValue(result, additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckRecordIsExist:
                    CheckRecordIsExist(result, additionnalInfo, critical);
                    break;
                case BusinessUtilMethod.CheckUniqueValue:
                    CheckUniqueValue(result, additionnalInfo);
                    break;
                case BusinessUtilMethod.CheckNothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static async Task GetByIntIdChecker<T, TRepository>(int id, TRepository repository) where T : BaseModel<int>, new()
                                                                                    where TRepository : IRepository<T>
        {
            var result = await repository.GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            CheckRecordIsExist(result, new T().GetType().Name);
        }

        public static async Task GetByLongIdChecker<T, TRepository>(long id, TRepository repository) where T : BaseModel<long>, new()
            where TRepository : IRepository<T>
        {
            var result = await repository.GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            CheckRecordIsExist(result, new T().GetType().Name);
        }

        public static void UniqueGenericListChecker<T>(T result, string additionalInfo, bool critical = false)
        {
            CheckDuplicatationForUniqueValue(result, additionalInfo.RemoveManagerString());
            CheckRecordIsExist(result, additionalInfo.RemoveManagerString(), critical);
        }

        public static void CheckDuplicatationForUniqueValue<T>(T result, string additionalInfo)
        {
            if (GetGenericTypeCount(result) <= 1) return;
            throw new DuplicateNameException(additionalInfo.RemoveManagerString());
        }

        public static void CheckRecordIsExist<T>(T result, string additionalInfo, bool critical = false)
        {
            if (!GenericTypeIsNullOrEmpty(result)) return;
            if (critical)
            {
                //TODO send mail
            }
            throw new KeyNotFoundException(additionalInfo.RemoveManagerString());
        }

        public static void CheckUniqueValue<T>(T result, string additionalInfo)
        {
            if (!GenericTypeIsNullOrEmpty(result)) throw new DuplicateNameException(additionalInfo.RemoveManagerString());
        }

        public static void FieldIsRequired(object value, string additionalInfo)
        {
            if (!(value is null)) return;
            throw new ArgumentException(additionalInfo.RemoveManagerString());
        }

        public static void FieldIsRequired(DateTime value, string additionalInfo)
        {
            if (value >= DateTime.Now.AddYears(-100)) return;
            throw new ArgumentException(additionalInfo.RemoveManagerString());
        }

        private static bool GenericTypeIsNullOrEmpty<T>(T value)
        {
            return GetGenericTypeCount(value) <= 0;
        }

        private static int GetGenericTypeCount<T>(T value)
        {
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