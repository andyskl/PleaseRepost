using Andyskl.Data.Model;
using MongoDB.Bson.Serialization;
namespace Andyskl.Data.Mappers
{
    public static class MongoMapper
    {
        public static void Map<T>()
        {
            BsonClassMap.RegisterClassMap<T>(classMap => classMap.AutoMap());
        }
        public static void MapAll()
        {
            Map<BaseEntity>();
        }
    }
}
