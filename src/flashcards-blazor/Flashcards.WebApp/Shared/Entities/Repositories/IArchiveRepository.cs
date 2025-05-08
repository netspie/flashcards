using Flashcards.WebApp.Shared.Expressions;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public interface IArchiveRepository<T, TId>
{
    Task Archive(TId id);
    Task Restore(TId id);
}