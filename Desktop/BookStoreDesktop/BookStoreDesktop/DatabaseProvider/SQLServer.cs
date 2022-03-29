using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.BookStoreDatabase;
using Microsoft.Extensions.Configuration;
using LibraryAbstractDBProvider;
namespace BookStoreDesktop.DatabaseProvider
{
    public class SQLServer : AbstractDBProvider
    {
        public override void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString(), x => x.MigrationsAssembly("SqlServerMigrations"));
        }
        public override string ConnectionString()
        {
            IConfigurationRoot config = GetStringAppsetting.ConnectString();
            return config.GetConnectionString("SQLServer");
        }
    }
}