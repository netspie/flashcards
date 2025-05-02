namespace Flashcards.WebApp.Shared.Entities;

public interface IEntity<TId>
{
    public TId Id { get; }
}