using System;
using System.Collections.Generic;

namespace Andyskl.Web.Authentication
{
    public class SessionManager
    {
        private readonly Dictionary<string, UserSession> _sessions = new Dictionary<string, UserSession>();
        private readonly Dictionary<Guid, string> _logins = new Dictionary<Guid, string>(); 

        public bool Authenticate(string login, string hash, bool isWindows, out Guid guid)
        {
            guid = new Guid();      

            //var session = new UserSession(login, password);
            if (!session.Success) return false;
            if (_sessions.ContainsKey(login))
            {
                Logout(_sessions[login].Guid);
            }
            _sessions.Add(login, session);
            _logins.Add(session.Guid, login);
            guid = session.Guid;
            return true;
        }

        public DirectumSession GetSession(Guid guid)
        {
            return _logins.ContainsKey(guid) 
                ? _sessions[_logins[guid]] 
                : null;
        }

        public IEnumerable<Guid> SessionIds
        {
            get
            {
                return _logins.Keys;
            }
        }

        public bool TryGetGuid(string login, out Guid guid)
        {

            if (!_sessions.ContainsKey(login))
            {
                guid = new Guid();
                return false;
            }
            guid = _sessions[login].Guid;
            return true;
        }

        public bool Logout(Guid guid)
        {
            if (!_logins.ContainsKey(guid)) return false;
            var login = _logins[guid];
            var session = _sessions[login];
            session.Context.Logout();
            _sessions.Remove(login);
            _logins.Remove(guid);
            return true;
        }
    }
}
