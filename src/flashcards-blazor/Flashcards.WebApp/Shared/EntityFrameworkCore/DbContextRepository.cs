using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextRepository<T, TId>(
    DbContext _context) : IRepository<T, TId>
    where T : class, IEntity<TId>, IUserOwned, IArchived
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();

    public async Task<T> GetById(TId id, bool includeArchived = false)
    {
        if (await _dbSet.FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public Task<T[]> GetMany(AliveState? lifeState = AliveState.Alive, string? userId = null)
    {
        var query = _dbSet.AsNoTracking().AsQueryable();

        query = lifeState switch
        {
            AliveState.Alive => query.Where(x => !x.IsArchived),
            AliveState.Archived => query.Where(x => x.IsArchived),
            _ => query,
        };

        query = userId switch
        {
            null => query,
            _ => query.Where(x => x.UserId == userId),
        };

        return query.ToArrayAsync();
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Archive(TId id)
    {
        if (await _dbSet.FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        if (entity.IsArchived)
            throw new InvalidOperationException($"Entity of {id} id is already archived");

        if (entity.GetType().GetProperty("IsArchived") is not PropertyInfo property ||
            property.PropertyType != typeof(bool))
        {
            throw new InvalidOperationException($"Entity of {id} id cannot be archived");
        }

        property.SetValue(entity, true);

        await _context.SaveChangesAsync();
    }

    public async Task Restore(TId id)
    {
        if (await _dbSet.FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        if (!entity.IsArchived)
            throw new InvalidOperationException($"Entity of {id} id has not been archived");

        if (entity.GetType().GetProperty("IsArchived") is not PropertyInfo property ||
                   property.PropertyType != typeof(bool))
        {
            throw new InvalidOperationException($"Entity of {id} id cannot be restored");
        }

        property.SetValue(entity, false);

        await _context.SaveChangesAsync();
    }
}