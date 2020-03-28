using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EduquayAPI.DataLayer
{
    public class DbConnect
    {
        private readonly SqlConnection _connection;
        public DbConnect()
        {
            var configuration = GetConfiguration();
            _connection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true,reloadOnChange:true);
            return builder.Build();
        }
    }
}
