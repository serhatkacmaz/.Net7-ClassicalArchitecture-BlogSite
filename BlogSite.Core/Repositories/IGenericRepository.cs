using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        
        void Updates(T entity); 
        
        void Deletes(T entity);
        void DeletesRange(IEnumerable<T> entities);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
