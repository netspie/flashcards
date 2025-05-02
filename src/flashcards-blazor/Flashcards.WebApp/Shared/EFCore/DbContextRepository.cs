using Flashcards.WebApp.Shared.DDD;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Flashcards.WebApp.Shared.EFCore;

public class DbContextRepository<T, TId>(
    DbContext _context, string _tableName) : IRepository<T, TId>
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

    public Task<T[]> GetMany(LifeState? lifeState = LifeState.Alive, string? UserId = null)
    {
        var sql = UserId is null ?
            FormattableStringFactory.Create($"SELECT * FROM {_tableName}") :
            FormattableStringFactory.Create($"SELECT * FROM {_tableName} WHERE user_id = '{UserId}'");

        return _dbSet
            .FromSql(sql)
            .AsNoTracking()
            .ToArrayAsync();
    }

    public string? GetTableName<TEntity>()
    {
        var entityType = _context.Model.FindEntityType(typeof(TEntity));
        return entityType?.GetTableName();
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