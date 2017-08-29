using System.Collections.Generic;
using System.Linq;

namespace Andyskl.Web.Authentication
{
    public static class UserContextProvider
    {
        private static readonly List<UserContext> UserContexts = new List<UserContext>();
        private static readonly AuthenticationTokenProvider TokenProvider = AuthenticationTokenProviderFactory.Get();

        public static UserContext Authenticate(string login, string password, bool isWindows)
        {
            var userContext = new UserContext(TokenProvider);
            
            userContext.Authenticate(login, password, isWindows);
            if (userContext.Valid)
            {
                if (UserContexts.Any(entry => entry.Token.Equals(userContext.Token))) 
                    UserContexts.RemoveAll(entry => entry.Token.Equals(userContext.Token));
                UserContexts.Add(userContext);
            }
            return userContext;
        }

        public static UserContext Authenticate(AuthenticationToken token)
        {
            return UserContexts.FirstOrDefault(entry => entry.Token.Equals(token)) ?? new UserContext(TokenProvider);
        }

        public static void Logout(AuthenticationToken token)
        {
            var context = UserContexts.FirstOrDefault(entry => entry.Token.Equals(token));
            Logout(context); 
        }

        private static void Logout(UserContext context)
        {
            if (context == null) return;
            context.Proxy.Logout();
            UserContexts.Remove(context);    
        }
    }
}
