using Andyskl.Web.Authentication.Cryptography;
using System;
using System.Collections.Generic;

namespace Andyskl.Web.Authentication
{
    public class AuthenticationTokenProvider
    {
        private readonly ISessionManager _sessionManager;
        private readonly Dictionary<Guid, DateTime> _tokenLifetimes = new Dictionary<Guid, DateTime>();
        private readonly IHashProvider _hashProvider;
        public AuthenticationTokenProvider(ISessionManager sessionManager, IHashProvider hashProvider)
        {
            _sessionManager = sessionManager;
            _hashProvider = hashProvider;
        }

        public AuthenticationToken Authenticate(string login, string password, bool isWindows)
        {
            Guid guid;
            Guid existingGuid;
            var guidExists = _sessionManager.TryGetGuid(login, out existingGuid);
            if (!_sessionManager.Authenticate(login, password, isWindows, out guid))
            {
                return null;
            }
            if (guidExists)
            {
                _tokenLifetimes.Remove(existingGuid);
            }
            var salt = Guid.NewGuid();
            var hash = _hashProvider.GenerateHash(guid, salt);
            var hashString = GetHashString(hash);
            if (!_tokenLifetimes.ContainsKey(guid))
                _tokenLifetimes.Add(guid, GetLifeTime());
            return new AuthenticationToken(hashString, salt);
        }

        public void Logout(AuthenticationToken token)
        {
            foreach (var sessionId in _sessionManager.SessionIds)
            {
                var tokenToCompare = GenerateToken(sessionId, token.Salt);
                if (!token.Equals(tokenToCompare)) continue;
                _sessionManager.Logout(sessionId);
                _tokenLifetimes.Remove(sessionId);
            }
        }

        public ContextProxy GetDirectumContext(ref AuthenticationToken token)
        {
            foreach (var sessionId in _sessionManager.SessionIds)
            {
                var tokenToCompare = GenerateToken(sessionId, token.Salt);
                if (!token.Equals(tokenToCompare)) continue;
                token = UpdateToken(token, sessionId);
                return _sessionManager.GetSession(sessionId).Context;
            }
            return null;
        }

        private AuthenticationToken UpdateToken(AuthenticationToken token, Guid guid)
        {
            if (!_tokenLifetimes.ContainsKey(guid)) return null;
            if (_tokenLifetimes[guid] >= DateTime.Now) return token;
            var newToken = GenerateToken(guid);
            _tokenLifetimes[guid] = GetLifeTime();
            return newToken;
        }
        private AuthenticationToken GenerateToken(Guid guid)
        {
            return GenerateToken(guid, Guid.NewGuid());
        }

        private AuthenticationToken GenerateToken(Guid guid, Guid salt)
        {
            var hash = _hashProvider.GenerateHash(guid, salt);
            var hashString = GetHashString(hash);
            //_tokenLifetimes.Add(hashString, GetLifeTime());
            return new AuthenticationToken(hashString, salt);
        }

        private static DateTime GetLifeTime()
        {
            return DateTime.Now + TimeSpan.FromMinutes(10);
        }

        private static string GetHashString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }
    }
}
