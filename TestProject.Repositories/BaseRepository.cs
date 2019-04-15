using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Repositories
{
    public class BaseRepository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContext dbContext;

        protected DbSet<T> DbSet { get; set; }

        public BaseRepository()
        {
        }

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> criteria)
        {
            return await DbSet.SingleOrDefaultAsync(criteria);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> criteria)
        {
            return await DbSet.AnyAsync(criteria);
        }

        public virtual IQueryable<T> GetAll(int? take = null)
        {
            return take.HasValue ? DbSet.Take(take.Value) : DbSet.AsQueryable();
        }


        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> criteria, int? take = null)
        {
            return take.HasValue ? DbSet.Where(criteria).Take(take.Value) : DbSet.Where(criteria);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await DbSet.CountAsync(criteria);
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return false;

            Delete(entity);
            return true;
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
