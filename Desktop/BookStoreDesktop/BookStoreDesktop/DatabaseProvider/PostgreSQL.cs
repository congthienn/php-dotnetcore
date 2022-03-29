using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.BookStoreDatabase;
using LibraryAbstractDBProvider;
namespace BookStoreDesktop.DatabaseProvider
{
    public class PostgreSQL : AbstractDBProvider
    {
        public override void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString(), x => x.MigrationsAssembly("PostgreSQLMigrations"));
        }
        public override string ConnectionString()
        {
            IConfigurationRoot config = GetStringAppsetting.ConnectString();
            return config.GetConnectionString("PostgreSQL");
        }
    }
}