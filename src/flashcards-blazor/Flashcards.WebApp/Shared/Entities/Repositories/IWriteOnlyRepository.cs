namespace Flashcards.WebApp.Shared.Entities;

public interface IWriteOnlyRepository<T, TId>
{
    Task Add(T entity);
    Task Update(T entity);
}
