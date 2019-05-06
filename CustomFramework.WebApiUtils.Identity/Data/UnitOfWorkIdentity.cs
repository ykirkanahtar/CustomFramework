using CustomFramework.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;
using CustomFramework.WebApiUtils.Identity.Models;

namespace CustomFramework.WebApiUtils.Identity.Data
{
    public class UnitOfWorkIdentity<TUser, TRole> : UnitOfWork<IdentityContext<TUser, TRole>>, IUnitOfWorkIdentity 
        where TUser : CustomUser
        where TRole : CustomRole
    {
        public UnitOfWorkIdentity(IdentityContext<TUser, TRole> context) : base(context)
        {
            ClientApplications = new ClientApplicationRepository(context);
        }

        public IClientApplicationRepository ClientApplications { get; }
    }
}