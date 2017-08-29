using Andyskl.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Andyskl.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<T> Get<T>();
        IEnumerable<T> Get<T>(Expression<Func<T, bool>> expression);
        T GetOne<T>(Guid guid) where T : BaseEntity;
        void Add<T>(T item);
        void Remove<T>(T item) where T: BaseEntity;
        void RemoveBy<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        bool Contains<T>(T item) where T : BaseEntity;
        bool ContainsBy<T>(Expression<Func<T, bool>> expression);
    }
}
