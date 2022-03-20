using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Interfaces.Services;
using BookStoreDesktop.Interfaces.Repository;
using BookStoreDesktop.Models;
using BookStoreDesktop.Autofac;
using BookStoreDesktop.Automapper;
namespace BookStoreDesktop.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService()
        {
            this._bookRepository = AutofacInstance.GetInstance<IBookRepository>();
        }

        public bool CheckCategoryId(int categoryId)
        {
            Book books = this._bookRepository.CheckCategoryId(categoryId);
            if(books is null)
            {
                return true;
            }
            MessageBox.Show("Không thể xóa dữ liệu, có nhiều dữ liệu liên quan", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public bool CreateBook(BookDTO book)
        {
            Book newBook = new Book();
            ConfigMapper.configMapper().Map(book,newBook);
            Book validateName = this._bookRepository.ValidateName(newBook.Name,newBook.Id);
            if(validateName!= null)
            {
                MessageBox.Show("Tên sách đã có, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this._bookRepository.CreateBook(newBook);
            return true;
        }

        public bool DeleteBook(string id)
        {
            Book book = this._bookRepository.GetBookById(id);
            if (book is null)
            {
                MessageBox.Show("Không tìm thấy sách phù hợp, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this._bookRepository.DeleteBook(book);
            return true;
        }

        public List<Book> GetAllBook()
        {
            return this._bookRepository.GetAllBook();
        }

        public Book GetBookById(string id)
        {
            return this._bookRepository.GetBookById(id);
        }

        public List<Book> GetBookByName(string name)
        {
            return this._bookRepository.GetBookByName(name);
        }

        public List<Book> GetBookByNameAndCategoryId(string name, int CategoryId)
        {
            return this._bookRepository.GetBookByNameAndCategory(name,CategoryId);
        }

        public bool UpdateBook(BookDTO book, string id)
        {
            Book findBook = this._bookRepository.GetBookById(id);
            if(book is null)
            {
                MessageBox.Show("Không tìm thấy sách phù hợp, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            ConfigMapper.configMapper().Map(book,findBook);
            Book validateBook = this._bookRepository.ValidateName(findBook.Name, findBook.Id);
            if(validateBook != null)
            {
                MessageBox.Show("Tên sách đã có, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this._bookRepository.UpdateBook(findBook);
            return true;
        }
    }
}
