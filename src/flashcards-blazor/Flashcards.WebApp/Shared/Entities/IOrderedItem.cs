namespace Flashcards.WebApp.Shared.Entities;

public interface IOrderedItem
{
    int Order { get; }
    IOrderedItem ChangeOrder(int order);
}