namespace Flashcards.WebApp.Shared.Entities;

public interface IOrdered
{
    int Order { get; }
    IOrdered ChangeOrder(int order);
}