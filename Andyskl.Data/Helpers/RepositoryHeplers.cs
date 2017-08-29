using Andyskl.Data.Model;
using MongoDB.Bson.Serialization;
using System;
namespace Andyskl.Data.Tools
{
    public static class RepositoryHelpers
    {
        public static string GetStorageName(Type t)
        {
            return t.ToString();
        }
    }
}
