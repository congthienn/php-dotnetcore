using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.BookStoreDatabase;
using Microsoft.Extensions.Configuration;

namespace BookStoreDesktop.DatabaseProvider
{
    public class SQLServer : IDatabaseProvider
    {
        public void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString(), x => x.MigrationsAssembly("SqlServerMigrations"));
        }
        public string ConnectionString()
        {
            IConfigurationRoot config = GetStringAppsetting.ConnectString();
            return config.GetConnectionString("SQLServer");
        }
    }
}