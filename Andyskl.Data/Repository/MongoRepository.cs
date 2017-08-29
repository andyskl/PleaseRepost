using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using Andyskl.Data.Tools;

namespace Andyskl.Data.Repository
{
    class MongoRepository : BaseRepository
    {
        private readonly MongoConnector _connector;

        public MongoRepository(string connectionString)
        {
            _connector = new MongoConnector(connectionString);
        }

        private IMongoCollection<T> GetCollection<T>()
        {
            return _connector
                .GetCollection<T>(
                    RepositoryHelpers.GetStorageName(typeof(T)));
        }
        public override IEnumerable<T> Get<T>()
        {
            return GetCollection<T>()
                .Find(entry => true)
                .ToEnumerable();
        }

        protected override IQueryable<T> GetAsQueryable<T>()
        {
            return GetCollection<T>().AsQueryable();
        }

        public override IEnumerable<T> Get<T>(Expression<Func<T, bool>> expression)
        {
            return GetCollection<T>()
                .Find(expression)
                .ToEnumerable();
        }

        public override T GetOne<T>(Guid guid)
        {
            return GetCollection<T>()
                .Find(entry => entry.Guid == guid)
                .FirstOrDefault();
        }

        public async override void Add<T>(T item)
        {
            await GetCollection<T>()
                .InsertOneAsync(item);
        }

        public async override void Remove<T>(T item)
        {             
            await GetCollection<T>()
                .DeleteOneAsync(entry => entry.Guid == item.Guid);
        }

        public async override void RemoveBy<T>(Expression<Func<T, bool>> expression)
        {
            await GetCollection<T>()
                .DeleteManyAsync(expression);
        }

        public override bool ContainsBy<T>(Expression<Func<T, bool>> expression)
        {
            return Get(expression).Any();
        }

        public override bool Contains<T>(T item)
        {
            return Get<T>(entry => entry.Guid == item.Guid).Any();
        }
    }
}
