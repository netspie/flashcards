using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public interface IReadOnlyRepository<T, TId>
{
    Task<T> GetById(TId id);
    Task<T[]> GetMany(Expression<Func<T, bool>>? filter = null);
}
