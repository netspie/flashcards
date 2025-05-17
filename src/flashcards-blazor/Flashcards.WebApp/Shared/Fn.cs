using System.Linq.Expressions;
using System.Reflection;

namespace Flashcards.WebApp.Shared;

public static class Fn
{
    public static void IfTrueDo(bool value, Action action)
    {
        if (value)
            action();
    }

    public static Task IfTrueDo(bool value, Func<Task> func) =>
        value ? func() : Task.CompletedTask;

    public static Action<TProperty> Setter<T, TProperty>(this T source, Expression<Func<T, TProperty>> property)
    {
        if (property.Body is not MemberExpression memberExpression)
            throw new ArgumentException("Expression must be a member expression", nameof(property));

        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (propertyInfo == null)
            throw new ArgumentException("Expression must refer to a property", nameof(property));

        var setMethod = propertyInfo.GetSetMethod();
        if (setMethod == null)
            throw new ArgumentException("Property does not have a setter", nameof(property));

        return value => setMethod.Invoke(source, new object[] { value });
    }

    public static Task IfNotNull<T>(this T? source, Func<T, Task> action)
    {
        if (source is null)
            return Task.CompletedTask;

        return action(source);
    }

    public static async ValueTask ThenAsync(this Task source, Func<Task?>? action)
    {
        await source;

        if (action is null)
            return;

        var task = action();
        if (task is not null)
            await task;
    }

    public static async ValueTask ThenAsync(this ValueTask source, Func<Task?>? action)
    {
        await source;
        
        if (action is null)
            return;

        var task = action();
        if (task is not null)
            await task;
    }
}