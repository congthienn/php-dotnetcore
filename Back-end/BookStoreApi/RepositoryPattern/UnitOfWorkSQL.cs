using BookStoreApi.DBContext;
using BookStoreApi.Models;
using LibraryAbstractDBProvider.DBContext;

namespace BookStoreApi.RepositoryPattern
{
    public class UnitOfWorkSQL : AbstractUnitOfWork
    {
        private SQLContext _context = new SQLContext();
        private GenericRepositorySQL<Category> _categoryRepository;
        private GenericRepositorySQL<Role> _roleRepository;
        private GenericRepositorySQL<User> _userRepository;
        private GenericRepositorySQL<Book> _bookRepository;
        private GenericRepositorySQL<Bill> _billRepository;
        private GenericRepositorySQL<BillDetail> _billDetailRepository;
        public override GenericRepositorySQL<Category> CategoryRepository
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
        public override GenericRepositorySQL<Role> RoleRepository
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
        public override GenericRepositorySQL<User> UserRepository
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
        public override GenericRepositorySQL<Book> BookRepository
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
        public override GenericRepositorySQL<Bill> BillRepository
        {
            get
            {
                if(this._billRepository == null)
                {
                    return this._billRepository = new GenericRepositorySQL<Bill>(_context);
                }
                return this._billRepository;
            }
        }
        public override GenericRepositorySQL<BillDetail> BillDetailRepository
        {
            get
            {
                if(this._billDetailRepository == null)
                {
                    return this._billDetailRepository = new GenericRepositorySQL<BillDetail>(_context);
                }
                return this._billDetailRepository;
            }
        } 
    }
}