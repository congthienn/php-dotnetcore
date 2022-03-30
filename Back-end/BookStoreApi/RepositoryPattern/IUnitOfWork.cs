using BookStoreApi.Models;

namespace BookStoreApi.RepositoryPattern
{
    public interface IUnitOfWork 
    {
        public IGenericRepository<Category> CategoryRepository { get; }
        public IGenericRepository<Role> RoleRepository { get; }
        public IGenericRepository<User> UserRepository { get; }
        public IGenericRepository<Book> BookRepository { get; }
        public IGenericRepository<Bill> BillRepository { get; }
        public IGenericRepository<BillDetail> BillDetailRepository { get; }
    }
}
