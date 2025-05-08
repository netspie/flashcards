using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Expressions;

public static class Filter<T>
{
    public static Expression<Func<T, bool>> New => x => true;
}
