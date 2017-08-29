namespace Andyskl.Web.Authentication
{
    public class UserContext
    {
        

        private readonly AuthenticationTokenProvider _provider;

        public UserContext(AuthenticationTokenProvider provider)
        {
            _provider = provider;
        }

        public void Authenticate(string login, string password, bool isWindows)
        {
            Token = _provider.Authenticate(login, password, isWindows);
        }

        public bool Valid
        {
            get
            {
                return Token != null;
            }
        }

        public ContextProxy Proxy
        {
            get
            {
                if (!Valid) return null;
                var token = Token;
                var context = _provider.GetDirectumContext(ref token);
                Token = token;
                return context;
            }
        }
        public AuthenticationToken Token { get; private set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserContext) obj);
        }
        protected bool Equals(UserContext other)
        {
            return Equals(Token, other.Token);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Token != null ? Token.GetHashCode() : 0);
            }
        }
    }
}
