using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public interface IDeleteOnlyRepository<T, TId>
{
    Task Delete(TId id);
    Task DeleteMany(IEnumerable<TId> ids);
    Task DeleteAll(Expression<Func<T, bool>>? filter = null);
}