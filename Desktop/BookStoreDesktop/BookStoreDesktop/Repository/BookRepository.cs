using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Interfaces.Repository;
using BookStoreDesktop.BookStoreDatabase;
using BookStoreDesktop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreDesktop.Repository
{
    public class BookRepository : IBookRepository
    {
        public Book CheckCategoryId(int categoryID)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Books.Where(x => x.CategoryId == categoryID).FirstOrDefault();
            }
        }

        public void CreateBook(Book book)
        {
           using(var _context = new BookStoreContext())
           {
                _context.Books.Add(book);
                _context.SaveChanges();
           }
        }

        public void DeleteBook(Book book)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBook()
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Books.AsNoTracking().OrderByDescending(x=>x.TimeCreate).ToList();
            }
        }

        public Book GetBookById(string id)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Books.Find(id);
            }
        }

        public List<Book> GetBookByName(string name)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Books.Where(x=>x.Name.Contains(name)).ToList();
            }
        }

        public List<Book> GetBookByNameAndCategory(string name, int categoryID)
        {
            using (var _context = new BookStoreContext())
            {
                return _context.Books.Where(x => x.Name.Contains(name) && x.CategoryId == categoryID).ToList();
            }
        }

        public void UpdateBook(Book book)
        {
            using (var _context = new BookStoreContext())
            {
                _context.Books.Update(book);
                _context.SaveChanges();
            }
        }

        public Book ValidateName(string name,string id)
        {
            using (var _context = new BookStoreContext())
            {
                return _context.Books.Where(x=>x.Id != id && x.Name == name).FirstOrDefault();
            }
        }
    }
}
