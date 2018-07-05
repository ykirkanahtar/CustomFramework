using System.Threading.Tasks;
using CustomFramework.Data;

namespace CustomFramework.WebApiUtils.Business
{
    public interface IBusinessManager<TEntity, in TCreateRequest, in TKey> where TEntity : BaseModel<TKey>
    {
        Task<TEntity> CreateAsync(TCreateRequest request);
        Task DeleteAsync(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
    }

    public interface IBusinessManager<TEntity, in TKey> where TEntity : BaseModel<TKey>
    {
        Task DeleteAsync(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}