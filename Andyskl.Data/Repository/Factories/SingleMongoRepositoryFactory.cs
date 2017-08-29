namespace Andyskl.Data.Repository.Factories
{
    public class SingleMongoRepositoryFactory : SingleRepositoryFactory
    {
        //"mongodb://localhost:27017/local"
        private readonly string _address;
        public SingleMongoRepositoryFactory(string address)
        {
            _address = address;
        }
        protected override IRepository Instantiate()
        {
            return new MongoRepository(_address);
        }
    }
}
