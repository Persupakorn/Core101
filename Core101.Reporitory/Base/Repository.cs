using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core101.Reporitory.Base
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected DbContext DbContext;
        protected DbSet<T> DbSet;

        protected Repository(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }
        public T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.FirstOrDefault(where);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.Where(where);
        }

        public T Add(T entity)
        {
            //clear change tracker that not related to input
            foreach (var entry in DbContext.ChangeTracker.Entries().Where(m => m.Entity != entity))
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is the Deleted, reload the date from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
            DbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
