using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.DatabaseProvider;
using BookStoreDesktop.BookStoreDatabase;

namespace BookStoreDesktop.DatabaseFactory
{
    public enum DBProvider
    {
        SQLServer,
        PostgreSQL
    }
    public class CreateDatabaseProvider
    {
        
        public IDatabaseProvider CreateDatabase()
        {  
            string databaseDefault = GetStringAppsetting.DatabaseDefault();
            switch (databaseDefault)
            {
                case nameof(DBProvider.SQLServer):
                    return new SQLServer();
                case nameof(DBProvider.PostgreSQL):
                    return new PostgreSQL();
                default:
                    throw new NotImplementedException("Default Database not a valid database type. Valid database: SQLServer - PostgerSQL");
            }
        }
    }
}