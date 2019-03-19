using System;
using CustomFramework.Utils;

namespace CustomFramework.WebApiUtils.Identity.Constants
{
    public static class IdentityUtilConstants
    {
        public static readonly int IterationCountForHashing =
            Convert.ToInt32(ConfigHelper.GetConfigurationValue("IterationCountForHashing") ?? "5");

    }
}