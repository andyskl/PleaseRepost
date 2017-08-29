using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andyskl.Web.Authentication
{
    public static class AuthenticationTokenProviderFactory
    {
        private static AuthenticationTokenProvider _instance;

        public static AuthenticationTokenProvider Get()
        {
            return _instance ??
                   (_instance = new AuthenticationTokenProvider(new SessionManager(), new Sha256HashProvider()));
        }
    }
}
