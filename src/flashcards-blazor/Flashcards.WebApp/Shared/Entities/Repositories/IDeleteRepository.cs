namespace Flashcards.WebApp.Shared.Entities.Repositories;

public interface IDeleteRepository<T, TId>
{
    Task Delete(TId id);
    Task DeleteMany(IEnumerable<TId> ids);
    Task DeleteAll();
}