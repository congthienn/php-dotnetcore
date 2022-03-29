using BookStoreApi.DBContext;
using BookStoreApi.Models;

namespace BookStoreApi.RepositoryPattern
{
    public class UnitOfWorkSQL : IDisposable
    {
        private SQLContext _context = new SQLContext();
        private GenericRepositorySQL<Category> _categoryRepository;
        private GenericRepositorySQL<Role> _roleRepository;
        private GenericRepositorySQL<User> _userRepository;
        private GenericRepositorySQL<Book> _bookRepository;
        public GenericRepositorySQL<Category> CategoryRepository
        {
            get
            {
                if(this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepositorySQL<Category>(_context);
                }
                return this._categoryRepository;
            }
        }
        public GenericRepositorySQL<Role> RoleRepository
        {
            get
            {
                if(this._roleRepository == null)
                {
                    this._roleRepository = new GenericRepositorySQL<Role>(_context);
                }
                return this._roleRepository;
            }
        }
        public GenericRepositorySQL<User> UserRepository
        {
            get
            {
                if(this._userRepository == null)
                {
                    this._userRepository = new GenericRepositorySQL<User>(_context);
                }
                return this._userRepository;
            }
        }
        public GenericRepositorySQL<Book> BookRepository
        {
            get
            {
                if(this._bookRepository == null)
                {
                    this._bookRepository = new GenericRepositorySQL<Book>(_context);
                }
                return this._bookRepository;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
