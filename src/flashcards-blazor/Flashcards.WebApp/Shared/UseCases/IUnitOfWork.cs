namespace Flashcards.WebApp.Shared.UseCases;

public interface IUnitOfWork
{
    void Start();
    Task Save();
}
