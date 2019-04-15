using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestProject.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(long id);

        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> criteria);

        Task<bool> AnyAsync(Expression<Func<T, bool>> criteria);

        IQueryable<T> GetAll(int? take = null);

        IQueryable<T> GetAll(Expression<Func<T, bool>> criteria, int? take = null);

        void Add(T entity);

        void Add(IEnumerable<T> entities);

        Task<bool> DeleteAsync(long id);

        void Delete(T entity);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> criteria);

        Task SaveChangesAsync();
    }
}
