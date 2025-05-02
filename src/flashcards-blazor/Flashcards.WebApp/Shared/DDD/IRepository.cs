namespace Flashcards.WebApp.Shared.DDD;

public interface IRepository<T, TId>
{
    Task<T> GetById(TId id, bool includeArchived = false);
    Task<T[]> GetMany(AliveState? state = AliveState.Alive, string? UserId = null);

    Task Add(T entity);
    Task Update(T entity);

    Task Archive(TId id);
    Task Restore(TId id);
}

public enum AliveState
{
    Alive,
    Archived,
}

public class NotFoundException(string message) : Exception(message) { }