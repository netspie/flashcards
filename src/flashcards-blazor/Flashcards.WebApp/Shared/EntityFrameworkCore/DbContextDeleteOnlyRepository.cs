using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextDeleteOnlyRepository<T, TId>(
    DbContext _context) : IDeleteOnlyRepository<T, TId>
    where T : class, IEntity<TId>
{
    private DbSet<T> _set = _context.Set<T>();

    public Task Delete(TId id) => _set
        .Join(set => set.FindAsync(id))
        .ThrowIfAsync((set, e) => e is not T entity, () => new NotFoundException($"Could not find entity of given id {id}"))
        .IOAsync((set, e) => set.Remove(e))
        .IOAsync(() => _context.SaveChangesAsync());

    public async Task DeleteMany(IEnumerable<TId> ids)
    {
        var entities = await _set
            .AsNoTracking()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
        
       _set.RemoveRange(entities);

        await _context.SaveChangesAsync();
    }

    public Task DeleteAll(Expression<Func<T, bool>>? filter) => _set
        .Join(set => set.AsNoTracking().AsQueryable())
        .MapLast((set, q) => filter is not null ? set.Where(filter) : q)
        .MapLastAsync((set, q) => q.ToListAsync())
        .IOAsync((set, e) => set.RemoveRange(e))
        .IOAsync(() => _context.SaveChangesAsync());
}