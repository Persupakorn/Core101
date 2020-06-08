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

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
