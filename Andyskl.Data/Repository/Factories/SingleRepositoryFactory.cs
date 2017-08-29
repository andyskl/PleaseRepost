using Andyskl.Data.Templates.Factories;

namespace Andyskl.Data.Repository.Factories
{
    public abstract class SingleRepositoryFactory : SingleInstanceFactory<IRepository>, IRepositoryFactory 
    {
        public IRepository GetRepository()
        {
            return Get();
        }
    }
}
