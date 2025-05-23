﻿using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class DbContextWriteOnlyRepository<T, TId>(
    DbContext _context) : IWriteOnlyRepository<T, TId>
    where T : class
{
    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddMany(IEnumerable<T> entities)
    {
        if (!entities.Any())
            return;

        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMany(IEnumerable<T> entities)
    {
        if (!entities.Any())
            return;

        _context.Set<T>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }
}