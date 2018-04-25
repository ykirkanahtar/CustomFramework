namespace CustomFramework.Data
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity,TKey> GetRepository<TEntity, TKey>() where TEntity : BaseModel<TKey>;
    }
}