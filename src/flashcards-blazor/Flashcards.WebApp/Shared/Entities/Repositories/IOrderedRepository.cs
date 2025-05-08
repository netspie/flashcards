namespace Flashcards.WebApp.Shared.Entities;

public interface IOrderedRepository<T, TId>
{
    Task Order(TId id, int order);
}