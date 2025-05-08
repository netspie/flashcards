using Flashcards.WebApp.Shared.Expressions;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public interface IArchived
{
    public bool IsArchived { get; }
}

public static class ArchivedFilterExtensions
{
    public static Expression<Func<T, bool>> FilterBy<T>(
        this Expression<Func<T, bool>> filter,
        AliveState? lifeState) where T : IArchived
    {
        return lifeState switch
        {
            AliveState.Alive => filter.And(x => !x.IsArchived),
            AliveState.Archived => filter.And(x => x.IsArchived),
            _ => filter
        };
    }
}