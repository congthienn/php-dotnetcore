using BookStoreApi.Models;
using BookStoreApi.Settings;
using BookStoreApi.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BookStoreApi.RepositoryPattern;
namespace BookStoreApi.Services
{
    public class BooksService : IBookService
    {
        private readonly UnitOfWorkSQL _unitOfWork;
        public BooksService(IOptions<BookStoreDatabaseSetting> bookStoreDataBaseSetting)
        {
            this._unitOfWork = new UnitOfWorkSQL();
        }
        public async Task<IEnumerable<Book>> GetAsync() => await this._unitOfWork.BookRepository.Get();
        public async Task<Book?> GetAsync(string id) => await this._unitOfWork.BookRepository.GetByID(id);
        public async Task CreateAsync(Book newBook) => await this._unitOfWork.BookRepository.Insert(newBook);
        public async Task UpdateAsync(string id,Book updateBook) => await this._unitOfWork.BookRepository.Update(updateBook);
        public async Task DeleteAsync(string id) => await this._unitOfWork.BookRepository.Delete(id);
        public async Task<IEnumerable<Book?>> ValidateBook(string id, string name) => await this._unitOfWork.BookRepository.Get(x=>x.ID != id && x.BookName == name);
        public async Task<IEnumerable<Book>> ListBookByCategoryId(string id) => await this._unitOfWork.BookRepository.Get(x=>x.CategoryId == id);
        
    }
}