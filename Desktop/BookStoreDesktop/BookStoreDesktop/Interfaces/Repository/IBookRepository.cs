using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Models;
namespace BookStoreDesktop.Interfaces.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();
        Book GetBookById(string id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        Book ValidateName(string name,string id);
        List<Book> GetBookByName(string name);
        List<Book> GetBookByNameAndCategory(string name,int categoryID);
        Book CheckCategoryId(int categoryID);
    }
}
