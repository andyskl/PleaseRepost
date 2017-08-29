using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andyskl.Web.Authentication.Cryptography
{
    public interface IHashProvider
    {
        byte[] GenerateHash(Guid data, Guid salt);
    }
}
