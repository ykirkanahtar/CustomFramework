using CustomFramework.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;

namespace CustomFramework.WebApiUtils.Identity.Data
{
    public class UnitOfWorkIdentity : UnitOfWork<IdentityContext>, IUnitOfWorkIdentity
    {
        public UnitOfWorkIdentity(IdentityContext context) : base(context)
        {
            ClientApplications = new ClientApplicationRepository(context);
        }

        public IClientApplicationRepository ClientApplications { get; }
    }
}