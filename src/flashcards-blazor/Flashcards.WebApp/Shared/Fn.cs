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

    public static Action<TProperty> Bind<T, TProperty>(this T source, Expression<Func<T, TProperty>> property)
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
}
