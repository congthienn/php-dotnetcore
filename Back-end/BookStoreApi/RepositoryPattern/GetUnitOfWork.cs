using LibraryAbstractDBProvider;
namespace BookStoreApi.RepositoryPattern
{
    public class GetUnitOfWork
    {
        public static IUnitOfWork UnitOfWork()
        {
            string databaseDefault = GetStringAppsetting.DatabaseDefault();
            try
            {
                if (databaseDefault.Equals("MongoDB"))
                {
                    return new UnitOfWorkMongoDB();
                }
                return new UnitOfWorkSQL();
            }
            catch
            {
                throw new NotImplementedException("Database deafault not a valid database type");
            }
        }
    }
}