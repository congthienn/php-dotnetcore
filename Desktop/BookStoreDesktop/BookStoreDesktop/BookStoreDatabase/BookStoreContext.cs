using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Models;
using BookStoreDesktop.DatabaseFactory;
namespace BookStoreDesktop.BookStoreDatabase
{
    public class BookStoreContext : DbContext
    {
        private readonly string ConnectionString;
        private readonly DBFactory dbFactory = new DBFactory();
        public BookStoreContext()
        {
            ConnectionString = dbFactory.GetDatabase().ConnectionString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            dbFactory.GetDatabase().ConnectedDatabase(optionsBuilder);
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