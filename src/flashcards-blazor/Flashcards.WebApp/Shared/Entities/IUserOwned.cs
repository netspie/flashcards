using Flashcards.WebApp.Shared.Expressions;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public interface IUserOwned
{
    public string UserId { get; }
}

public static class UserOwnedFilterExtensions
{
    public static Expression<Func<T, bool>> FilterBy<T>(
        this Expression<Func<T, bool>> filter,
        string? userId) where T : IUserOwned
    {
        return userId switch
        {
            null => filter,
            _ => filter.And(x => x.UserId == userId)
        };
    }
}