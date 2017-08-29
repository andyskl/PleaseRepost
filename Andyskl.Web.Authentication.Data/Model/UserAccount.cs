using Andyskl.Data.Model;

namespace Andyskl.Web.Authentication.Data.Model
{
    class UserAccount : BaseEntity
    {
        public string Login { get; set; }
        public Hash Hash { get; set; }
    }
}
