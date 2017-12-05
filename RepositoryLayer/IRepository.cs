using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    public interface IRepository<T>
    {
        IQueryable<T> Table { get; }
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        IQueryable<T> AsQuerable();
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}
