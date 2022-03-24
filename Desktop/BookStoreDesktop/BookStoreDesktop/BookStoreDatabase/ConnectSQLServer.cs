using BookStoreDesktop.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDesktop.BookStoreDatabase
{
    static class ConnectSQLServer
    {
        public static string DatabaseDefault()
        {
            var config = new ConfigurationBuilder().
                SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
                AddJsonFile("appsettings.json").Build();
            var databaseDefault = config.GetSection("DatabaseDefault").Value;
            return databaseDefault;
        }
        public static string ConnectString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var databaseDefault = DatabaseDefault();
            var connectionString = "";
            if (databaseDefault == "SQLServer")
            {
                connectionString = config.GetConnectionString("SQLServer");
            }
            else if(databaseDefault == "PostgreSQL")
            {
                connectionString = config.GetConnectionString("PostgreSQL");
            }
            return connectionString;
        }
    }
}