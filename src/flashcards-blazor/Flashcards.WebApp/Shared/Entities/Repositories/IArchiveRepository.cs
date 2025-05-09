namespace Flashcards.WebApp.Shared.Entities;

public interface IArchiveRepository<T, TId>
{
    Task Archive(TId id);
    Task Restore(TId id);
}