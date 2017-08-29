using Andyskl.Data.Repository;
using Andyskl.Data.Repository.Agents;
using Andyskl.Data.Repository.Factories;
using Andyskl.Web.Authentication.Data.Model;

namespace Andyskl.Web.Authentication.Data.Agents
{
    class UserAccountAgent : BaseRepositoryAgent<UserAccount>
    {
        public UserAccountAgent(IRepository repository) : base(repository) { }

        public UserAccountAgent(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
    }
}
