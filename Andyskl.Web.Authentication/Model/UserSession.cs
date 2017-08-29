using System;
namespace Andyskl.Web.Authentication
{
    public class UserSession
    {          
        public string Login { get; set; }
        public Guid Guid { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserSession) obj);
        }
        protected bool Equals(UserSession other)
        {
            return string.Equals(Guid, other.Guid) || string.Equals(Login, other.Login);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return Login.GetHashCode();
            }
        }
    }
}
