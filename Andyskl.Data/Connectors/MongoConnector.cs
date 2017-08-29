using MongoDB.Driver;

namespace Andyskl.Data
{
    class MongoConnector
    {
        private readonly MongoClient _client;
        private readonly string _databaseName;
        private MongoUrl MongoUrl { get; set; }

        public MongoConnector(string connectionString)
        {
            MongoUrl = MongoUrl.Create(connectionString);
            _databaseName = MongoUrl.DatabaseName;
            _client = new MongoClient(connectionString);
        }

        private IMongoDatabase Database
        {
            get
            {
                return _client.GetDatabase(_databaseName);
            }
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }
    }
}
