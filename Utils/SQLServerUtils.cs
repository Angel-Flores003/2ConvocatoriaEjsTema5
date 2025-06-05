using Microsoft.Extensions.Configuration;
using System.IO;

namespace daoexample.Persistence.Utils
{
    public class SQLServerUtils
    {
        public static string OppenConnection()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            return config.GetConnectionString("DefaultConnection");
        }
    }
}