namespace Andyskl.Data.Repository.Factories
{
    public class SingleAggregateRepositoryFactory : SingleRepositoryFactory
    {
        protected override IRepository Instantiate()
        {
            return new AggregateRepository();
        }
    }
}
