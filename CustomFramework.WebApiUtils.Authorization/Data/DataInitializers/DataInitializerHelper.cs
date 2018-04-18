using CustomFramework.Data.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Data.DataInitializers
{
    public static class DataInitializerHelper
    {
        public static string HashPassword(this string password, out string salt, int iterationCount)
        {
            salt = HashString.GetSalt();
            return HashString.Hash(password, salt, iterationCount);
        }
    }
}