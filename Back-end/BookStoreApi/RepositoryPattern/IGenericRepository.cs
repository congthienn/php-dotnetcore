using System.Linq.Expressions;

namespace BookStoreApi.RepositoryPattern
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(
           Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Delete(object id);
        Task Delete(TEntity entityDelete);
        Task Update(TEntity entityUpdate);
    }
}