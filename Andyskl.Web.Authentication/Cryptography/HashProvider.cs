using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Andyskl.Web.Authentication.Cryptography
{
    abstract class HashProvider : IHashProvider
    {
        protected abstract HashAlgorithm GetAlgorithm();
        public byte[] GenerateHash(Guid data, Guid salt)
        {
            var algorithm = GetAlgorithm();
            var byteData = data.ToByteArray();
            var byteSalt = salt.ToByteArray();
            var byteInput = byteData.Concat(byteSalt).ToArray();
            return algorithm.ComputeHash(byteInput);    
        }
    }
}
