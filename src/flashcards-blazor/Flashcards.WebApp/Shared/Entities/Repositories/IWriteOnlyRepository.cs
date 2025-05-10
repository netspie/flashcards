namespace Flashcards.WebApp.Shared.Entities;

public interface IWriteOnlyRepository<T, TId>
{
    Task Add(T entity);
    Task AddMany(IEnumerable<T> entities);

    Task Update(T entity);
    Task UpdateMany(IEnumerable<T> entities);
}