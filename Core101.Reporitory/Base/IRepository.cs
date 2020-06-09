using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core101.Reporitory.Base
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        T Add(T entity);
    }
}
