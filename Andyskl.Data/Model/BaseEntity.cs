using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Andyskl.Data.Model
{
    public abstract class BaseEntity
    {
        [BsonId]
        public Guid Guid { get; protected set; }

        protected BaseEntity()
        {
            Guid = Guid.NewGuid();
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var entity = obj as BaseEntity;
            return entity != null && entity.Guid.Equals(Guid);
        }
    }
}
