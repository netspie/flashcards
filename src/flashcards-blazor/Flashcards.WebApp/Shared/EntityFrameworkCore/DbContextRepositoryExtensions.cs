using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public static class DbContextRepositoryExtensions
{
    public static async Task<T> GetById<T, TId>(
        this DbContext context, TId id) 
        where T : class
    {
        var set = context.Set<T>();
        if (await set.FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public static Task<T[]> GetMany<T>(
        this DbSet<T> set,
        Expression<Func<T, bool>>? filter = null)
        where T : class
    {
        var query = set.AsNoTracking().AsQueryable();

        if (filter is not null)
            query = query.Where(filter);

        return query.ToArrayAsync();
    }

    public static async Task Archive<T, TId>(
        this DbContext context,
        TId id) where T : class, IArchived
    {
        if (await context.Set<T>().FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        if (entity.IsArchived)
            throw new InvalidOperationException($"Entity of {id} id is already archived");

        if (entity.GetType().GetProperty("IsArchived") is not PropertyInfo property ||
            property.PropertyType != typeof(bool))
        {
            throw new InvalidOperationException($"Entity of {id} id cannot be archived");
        }

        property.SetValue(entity, true);

        await context.SaveChangesAsync();
    }

    public static async Task Restore<T, TId>(
        this DbContext context,
        TId id) where T : class, IArchived
    {
        if (await context.Set<T>().FindAsync(id) is not T entity)
            throw new NotFoundException($"Could not find entity of given id {id}");

        if (!entity.IsArchived)
            throw new InvalidOperationException($"Entity of {id} id has not been archived");

        if (entity.GetType().GetProperty("IsArchived") is not PropertyInfo property ||
                   property.PropertyType != typeof(bool))
        {
            throw new InvalidOperationException($"Entity of {id} id cannot be restored");
        }

        property.SetValue(entity, false);

        await context.SaveChangesAsync();
    }
}