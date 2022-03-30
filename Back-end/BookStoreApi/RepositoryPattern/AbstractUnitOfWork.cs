using BookStoreApi.Models;

namespace BookStoreApi.RepositoryPattern
{
    public abstract class AbstractUnitOfWork : IUnitOfWork
    {
        public abstract IGenericRepository<Category> CategoryRepository { get; }
        public abstract IGenericRepository<Role> RoleRepository { get; }
        public abstract IGenericRepository<User> UserRepository { get; }
        public abstract IGenericRepository<Book> BookRepository { get; }
        public abstract IGenericRepository<Bill> BillRepository { get; }
        public abstract IGenericRepository<BillDetail> BillDetailRepository { get; }
    }
}
