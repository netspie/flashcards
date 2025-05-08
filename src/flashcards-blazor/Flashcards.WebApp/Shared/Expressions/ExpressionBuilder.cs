using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Expressions;

public static class ExpressionBuilder
{
    public static Expression<Func<T, bool>> And<T>(
        this Expression<Func<T, bool>> first,
        Expression<Func<T, bool>> second)
    {
        var param = Expression.Parameter(typeof(T));

        var body = Expression.AndAlso(
            Expression.Invoke(first, param),
            Expression.Invoke(second, param)
        );

        return Expression.Lambda<Func<T, bool>>(body, param);
    }
}
