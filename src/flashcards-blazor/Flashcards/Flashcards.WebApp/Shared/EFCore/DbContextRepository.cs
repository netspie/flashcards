using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Shared.EFCore;

public class DbContextRepository<T, TId>(DbContext _context) : IRepository<T, TId>
    where T : class
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();

    public async Task<T> GetById(TId id, bool includeArchived = false)
    {
        if (await _dbSet.FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public Task<ImmutableArray<T>> GetMany(LifeState? lifeState = LifeState.Alive)
    {
        return _dbSet.AsNoTracking().ToImmutableArrayAsync();
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

    public Task Archive(TId id)
    {
        throw new NotImplementedException();
    }

    public Task Restore(TId id)
    {
        throw new NotImplementedException();
    }
}

public interface IRepository<T, TId>
{
    Task<T> GetById(TId id, bool includeArchived = false);
    Task<ImmutableArray<T>> GetMany(LifeState? lifeState = LifeState.Alive);

    Task Add(T entity);
    Task Update(T entity);

    Task Archive(TId id);
    Task Restore(TId id);
}

public enum LifeState
{
    Alive,
    Archived,
}

public class NotFoundException(string message) : Exception(message) {}

public static class DbSetExtensions
{
    public static async Task<ImmutableArray<T>> ToImmutableArrayAsync<T>(this IQueryable<T> set)
        where T : class
    {
        var list = await set.ToListAsync();
        return list.ToImmutableArray();
    }
}