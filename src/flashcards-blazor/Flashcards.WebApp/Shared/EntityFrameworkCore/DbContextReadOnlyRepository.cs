using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextReadOnlyRepository<T, TId>(
    DbContext _context) : IReadOnlyRepository<T, TId>
    where T : class
{
    public Task<T> GetById(TId id) =>
        _context.GetById<T, TId>(id);

    public Task<T[]> GetMany(Expression<Func<T, bool>>? filter = null) =>
        _context.Set<T>().GetMany(filter);
}
