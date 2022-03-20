using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Models;
namespace BookStoreDesktop.Interfaces.Services
{
    public interface IBookService
    {
        List<Book> GetAllBook();
        Book GetBookById(string id);
        bool CreateBook(BookDTO book);
        bool UpdateBook(BookDTO book, string id);
        bool DeleteBook(string id);
        List<Book> GetBookByName(string name);
        List<Book> GetBookByNameAndCategoryId(string name, int CategoryId);
        bool CheckCategoryId(int categoryId);
    }
}
