using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretApi.Persistence
{
    static class Configuration
    {
        private static readonly string _connectionString;

        static Configuration()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/EticaretApi.Api"));
            configurationManager.AddJsonFile("appsettings.json");

            _connectionString = configurationManager.GetConnectionString("DefaultConnection");
        }

        public static string ConnectionString => _connectionString;
    }
}
