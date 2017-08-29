using Andyskl.Data.Model;
using Andyskl.Data.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Andyskl.Data.Repository
{
    public class AggregateRepository : BaseRepository
    {
        private readonly Dictionary<string, List<object>> _items = new Dictionary<string, List<object>>();

        private string CreateListOf(Type t)
        {
            var caption = RepositoryHelpers.GetStorageName(t);
            if (!_items.ContainsKey(caption)) _items.Add(caption, new List<object>());
            return caption;
        }
        public override IEnumerable<T> Get<T>()
        {
            var key = CreateListOf(typeof(T));
            return _items[key].Select(item => (T)item);
        }

        protected override IQueryable<T> GetAsQueryable<T>()
        {
            var key = CreateListOf(typeof(T));
            return _items[key].Select(item => (T)item).AsQueryable();
        }

        public override T GetOne<T>(Guid guid)
        {
            var key = CreateListOf(typeof(T));
            return (T) _items[key].FirstOrDefault(item => (item as BaseEntity).Guid == guid);
        }

        public override void Add<T>(T item)
        {
            var key = CreateListOf(typeof(T));
            _items[key].Add(item);
        }
        public override void Remove<T>(T item)
        {
            var key = CreateListOf(typeof(T));
            _items[key].Remove(item);
        }

        public override void RemoveBy<T>(Expression<Func<T, bool>> expression)
        {
            var key = CreateListOf(typeof(T));
            _items[key].RemoveAll(x => expression.Compile()((T)x));
        }

        public override bool ContainsBy<T>(Expression<Func<T, bool>> expression)
        {
            return GetAsQueryable<T>().Any(expression.Compile().Invoke);
        }

        public override bool Contains<T>(T item)
        {
            var key = CreateListOf(typeof(T));
            return _items[key].Contains(item);
        }
    }
}
