using Andyskl.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Andyskl.Data.Repository
{
    public abstract class BaseRepository : IRepository
    {
        public abstract IEnumerable<T> Get<T>();
        protected abstract IQueryable<T> GetAsQueryable<T>(); 
        public abstract T GetOne<T>(Guid guid) where T : BaseEntity;    
        public abstract void Add<T>(T item);
        public abstract void Remove<T>(T item) where T : BaseEntity;
        public abstract bool Contains<T>(T item) where T : BaseEntity;
        public abstract void RemoveBy<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        public abstract bool ContainsBy<T>(Expression<Func<T, bool>> expression);
        public virtual IEnumerable<T> Get<T>(Expression<Func<T, bool>> expression)
        {
            return GetAsQueryable<T>().Where(expression);
        }
    }
}
