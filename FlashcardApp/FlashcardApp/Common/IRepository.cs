namespace FlashcardApp.Common;

public interface IRepository<TEntity>
{
    Task<TEntity> GetBy(string id);
    Task<TEntity[]> GetBy(IList<string> ids);
    Task<TEntity[]> GetAll();
    Task<bool> Update(TEntity item);
    Task<bool> Create(TEntity item);
    Task<bool> Create(IEnumerable<TEntity> items);
    Task<bool> Delete(string id);
}
