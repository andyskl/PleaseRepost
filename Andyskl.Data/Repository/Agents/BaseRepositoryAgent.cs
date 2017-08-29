using Andyskl.Data.Model;
using Andyskl.Data.Repository.Factories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Andyskl.Data.Repository.Agents
{
    public abstract class BaseRepositoryAgent<T> where T : BaseEntity
    {
        private IRepository _repository;

        public void Assign(IRepository repository)
        {
            _repository = repository;
        }
        protected BaseRepositoryAgent(IRepository repository)
        {
            _repository = repository;
        }

        protected BaseRepositoryAgent(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.GetRepository();
        }
        public virtual IEnumerable<T> Get()
        {
            return _repository.Get<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _repository.Get(expression);
        }

        public virtual T GetOne(Guid guid)
        {
            return _repository.GetOne<T>(guid);
        }

        public virtual void Add(T item)
        {
            _repository.Add(item);
        }

        public virtual void Remove(T item)
        {
            _repository.Remove(item);
        }

        public virtual void RemoveBy(Expression<Func<T, bool>> expression)
        {
            _repository.RemoveBy(expression);
        }

        public virtual bool Contains(T item)
        {
            return _repository.Contains(item);
        }

        public virtual bool ContainsBy(Expression<Func<T, bool>> expression)
        {
            return _repository.ContainsBy(expression);
        }
    }
}
