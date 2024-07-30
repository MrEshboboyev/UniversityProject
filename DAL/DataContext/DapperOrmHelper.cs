using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class DapperOrmHelper : IDapperOrmHelper
    {
        private readonly IConfiguration _configuration;


        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }

        public DapperOrmHelper(IConfiguration configuration)
        {
            _configuration = configuration;

            // Dapper Setting
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            ProviderName = "Npgsql";
        }

        // Dapper Connection String
        public IDbConnection GetDapperContextHelper()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
