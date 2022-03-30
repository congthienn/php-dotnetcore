using BookStoreApi.DBContext;
using BookStoreApi.Models;
using LibraryAbstractDBProvider.DBContext;

namespace BookStoreApi.RepositoryPattern
{
    public class UnitOfWorkMongoDB : AbstractUnitOfWork
    {
        private MongoDBContext mongoContext = new MongoDBContext();
        private GenericRepositoryMongoDB<Category> _categoryRepository;
        private GenericRepositoryMongoDB<Role> _roleRepository;
        private GenericRepositoryMongoDB<User> _userRepository;
        private GenericRepositoryMongoDB<Book> _bookRepository;
        private GenericRepositoryMongoDB<Bill> _billRepository;
        private GenericRepositoryMongoDB<BillDetail> _billDetailRepository;
        public override GenericRepositoryMongoDB<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepositoryMongoDB<Category>(mongoContext);
                }
                return this._categoryRepository;
            }
        }
        public override GenericRepositoryMongoDB<Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new GenericRepositoryMongoDB<Role>(mongoContext);
                }
                return this._roleRepository;
            }
        }
        public override GenericRepositoryMongoDB<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepositoryMongoDB<User>(mongoContext);
                }
                return this._userRepository;
            }
        }
        public override GenericRepositoryMongoDB<Book> BookRepository
        {
            get
            {
                if (this._bookRepository == null)
                {
                    this._bookRepository = new GenericRepositoryMongoDB<Book>(mongoContext);
                }
                return this._bookRepository;
            }
        }
        public override GenericRepositoryMongoDB<Bill> BillRepository
        {
            get
            {
                if (this._billRepository == null)
                {
                    return this._billRepository = new GenericRepositoryMongoDB<Bill>(mongoContext);
                }
                return this._billRepository;
            }
        }
        public override GenericRepositoryMongoDB<BillDetail> BillDetailRepository
        {
            get
            {
                if (this._billDetailRepository == null)
                {
                    return this._billDetailRepository = new GenericRepositoryMongoDB<BillDetail>(mongoContext);
                }
                return this._billDetailRepository;
            }
        }
    }
}