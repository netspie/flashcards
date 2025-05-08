using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class OrderedDbContextRepository<T, TId>(
    DbContext _context,
    Expression<Func<T, bool>>? _filter) : IOrderedRepository<T, TId> 
    where T : class, IOrdered 
{
    public async Task Order(TId id, int order)
    {
        var set = _context.Set<T>();

        if (await set.FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        var query = set.AsNoTracking().AsQueryable();

        if (_filter is not null)
            query = query.Where(_filter);

        var entities = await query.Where(x => x.Order > entity.Order).ToListAsync();

        var reorderedEntities = entities
            .Select((x, i) => (T) x.ChangeOrder(entity.Order + i + 1))
            .Append(entity);

        set.UpdateRange(reorderedEntities);
    }
}   