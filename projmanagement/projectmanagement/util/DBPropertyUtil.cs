using Microsoft.Extensions.Configuration;
using System.IO;

namespace projectmanagement.util
{
    internal class DBPropertyUtil
    {
        private static IConfigurationRoot Configuration { get; set; }

        static DBPropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Sets the base path to the current directory
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Adds appsettings.json

            Configuration = builder.Build(); // Build the configuration
        }

        // Static method to get the connection string
        public static string GetConnectionString()
        {
            return Configuration.GetConnectionString("LocalConnectionString");
        }
    }
}
