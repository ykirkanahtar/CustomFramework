using System;
using CustomFramework.WebApiUtils.Utils;

namespace CustomFramework.WebApiUtils.Constants
{
    public class WebApiUtilConstants
    {
        public static readonly string DefaultRoute = ConfigHelper.GetConfigurationValue("AppSettings:DefaultRoute") ?? "api/";
        public static readonly string AdminRoute = ConfigHelper.GetConfigurationValue("AppSettings:AdminRoute") ?? DefaultRoute + "admin/";
        public static readonly int DefaultListCount = Convert.ToInt32(ConfigHelper.GetConfigurationValue("AppSettings:DefaultListCount") ?? "50");
    }
}