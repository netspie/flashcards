namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public interface IUnitOfWork
{
    void Start();
    Task Save();
}

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