using CustomFramework.Data;

namespace CustomFramework.WebApiUtils.Authorization.Data.DataInitializers
{
    public class BaseDataInitializer
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseDataInitializer(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
