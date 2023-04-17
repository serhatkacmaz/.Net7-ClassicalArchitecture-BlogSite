using System.Linq.Expressions;

namespace BlogSite.Core.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(object id);
        IQueryable<T> GetAll();

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
    }
}
