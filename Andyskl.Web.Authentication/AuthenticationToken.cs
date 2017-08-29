using System;
using Newtonsoft.Json;

namespace Andyskl.Web.Authentication
{
    public class AuthenticationToken
    {     
        public AuthenticationToken() { }

        public AuthenticationToken(string hash, Guid salt)
        {
            Hash = hash;
            Salt = salt;
        }   
        [JsonProperty]
        public string Hash { get; private set; }
        [JsonProperty]
        public Guid Salt { get; private set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AuthenticationToken)obj);
        }
        protected bool Equals(AuthenticationToken other)
        {
            return string.Equals(Hash, other.Hash);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Hash.GetHashCode();
            }
        }
    }
}
