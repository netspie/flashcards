using Flashcards.WebApp.Shared.UseCases;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextUnitOfWork : IUnitOfWork
{
    public Task Save()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        throw new NotImplementedException();
    }
}