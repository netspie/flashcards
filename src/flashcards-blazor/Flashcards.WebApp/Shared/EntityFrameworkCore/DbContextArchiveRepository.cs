using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextArchiveRepository<T, TId>(
    DbContext _context) : IArchiveRepository<T, TId>
    where T : class, IArchived
{
    public Task Archive(TId id) =>
        _context.Archive<T, TId>(id);

    public Task Restore(TId id) =>
        _context.Restore<T, TId>(id);
}
