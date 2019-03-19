using CustomFramework.Data;
using CustomFramework.WebApiUtils.Identity.Data.Repositories;

namespace CustomFramework.WebApiUtils.Identity.Data
{
    public interface IUnitOfWorkIdentity : IUnitOfWork
    {
        IClientApplicationRepository ClientApplications { get; }
    }
}