namespace CustomFramework.Data
{
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets the specified repository for the <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TKey">The type of id value</typeparam>
        /// <returns>An instance of type inherited from <see cref="IRepository{TEntity}"/> interface.</returns>
        IRepository<TEntity> GetRepository<TEntity, TKey>() where TEntity : BaseModel<TKey>;
    }
}