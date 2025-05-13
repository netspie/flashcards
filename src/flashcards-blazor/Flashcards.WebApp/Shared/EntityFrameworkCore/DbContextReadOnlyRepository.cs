using Flashcards.WebApp.Shared.Entities;
using Mediator;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextReadOnlyRepository<T, TId>(
    DbContext _context) : IReadOnlyRepository<T, TId>
    where T : class, IEntity<TId>
{
    public Task<int> Count(Expression<Func<T, bool>>? filter = null)
    {
        var query = _context.Set<T>().AsNoTracking().AsQueryable();
        if (filter is not null)
            query = query.Where(filter);

        return query.CountAsync();
    }

    public Task<T> GetById(TId id) =>
        _context.GetById<T, TId>(id);

    public Task<T[]> GetMany(Expression<Func<T, bool>>? filter = null) =>
        _context.Set<T>().GetMany(filter);
}