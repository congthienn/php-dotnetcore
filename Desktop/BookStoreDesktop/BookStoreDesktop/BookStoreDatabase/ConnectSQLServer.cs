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
        public static string ConnectString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("PostgreSQL");
            return connectionString;
        }
    }
}