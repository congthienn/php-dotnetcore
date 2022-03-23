using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Models;
using BookStoreDesktop.BookStoreDatabase;
namespace BookStoreDesktop.BookStoreDatabase
{
    public class BookStoreContext : DbContext
    {
        private readonly string ConnectionString;
        public BookStoreContext()
        {
            ConnectionString = ConnectSQLServer.ConnectString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConnectionString,x=>x.MigrationsAssembly("SqlServerMigrations"));
            optionsBuilder.UseNpgsql(ConnectionString, x => x.MigrationsAssembly("PostgreSQLMigrations"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(b => b.Id).ValueGeneratedOnAdd();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}