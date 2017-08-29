using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Andyskl.Web.Authentication.Cryptography
{
    class Sha256HashProvider : HashProvider
    {
        protected override HashAlgorithm GetAlgorithm()
        {
            return new SHA256Managed();
        }
    }
}
