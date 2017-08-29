using Andyskl.Data.Model;
using Andyskl.Data.Repository.Factories;

namespace Andyskl.Data.Repository.Agents
{
    public class RepositoryAgent<T> : BaseRepositoryAgent<T> where T : BaseEntity
    {
        public RepositoryAgent(IRepository repository) : base(repository) { }
        public RepositoryAgent(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
    }
}
