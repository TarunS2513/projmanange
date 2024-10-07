using Microsoft.Extensions.Configuration;
using System.IO;

namespace projectmanagement.util
{
    public class DBConnUtil
    {
        private static IConfigurationRoot Configuration { get; set; }

        static DBConnUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return Configuration.GetConnectionString("LocalConnectionString");
        }
    }
}
