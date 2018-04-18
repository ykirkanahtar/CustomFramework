using System;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Authorization.Constants
{
    public static class AuthorizationUtilConstants
    {
        public static readonly int IterationCountForHashing =
            Convert.ToInt32(ConfigHelper.GetConfigurationValue("AppSettings:IterationCountForHashing") ?? "50");
    }
}