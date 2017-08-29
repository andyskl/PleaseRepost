using System;
using System.Security.Cryptography;
using System.Text;

namespace Andyskl.Data.Tools
{
    static class GuidExtensions
    {
        public static Guid ToGuid(this string value)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data);
        } 
    }
}
