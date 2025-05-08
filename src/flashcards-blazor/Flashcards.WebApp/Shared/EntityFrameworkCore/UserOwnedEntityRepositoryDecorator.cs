using Flashcards.WebApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public class UserOwnedEntityDbContextRepositoryDecorator<T, TId>(
    DbContext _context,
    IRepository<T, TId> _repository) : IRepository<T, TId> 
    where T : class, IUserOwned, IArchived
{
    public Task<T> GetById(TId id, bool includeArchived = false) =>
        _repository.GetById(id, includeArchived);

    public Task<T[]> GetMany(AliveState? state, string? userId = null) =>
        userId is null ?
            _context.Set<T>().GetMany(state, userId) :
            _context.Set<T>().GetMany(state, userId, filter: x => x.UserId == userId);

    public Task Add(T entity) => 
        _repository.Add(entity);

    public Task Update(T entity) =>
        _repository.Update(entity);

    public Task Archive(TId id) =>
        _repository.Archive(id);

    public Task Restore(TId id) =>
        _repository.Restore(id);
}