using System.IO;
using Microsoft.Extensions.Configuration;

namespace CustomFramework.Utils
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static string GetConfigurationValue(string key, string fileName = "appsettings.json")
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName);
            Configuration = builder.Build();

            return Configuration[key];
        }
    }
}
