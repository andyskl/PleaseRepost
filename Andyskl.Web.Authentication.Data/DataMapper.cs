using Andyskl.Data.Mappers;
using Andyskl.Web.Authentication.Data.Model;

namespace Andyskl.Web.Authentication.Data
{
    class DataMapper
    {
        public static void MapAll()
        {
            MongoMapper.MapAll();
            MongoMapper.Map<UserAccount>();
        }
    }
}
