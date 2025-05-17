namespace Flashcards.WebApp.Shared.Collections;

public static class EnumerableTreeExtensions
{
    public static T? FindRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>?> getChildren, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                return item;

            var children = getChildren(item);
            if (children is not null && FindRecursive(children, getChildren, predicate) is T found)
                return found;
        }

        return default;
    }

    public static void ForEachRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>?> getChildren, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);

            var children = getChildren(item);
            if (children is not null)
                ForEachRecursive(children, getChildren, action);
        }
    }

    public static Task ForEachRecursiveAsync<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>?> getChildren, Func<T, Task> action)
    {
        var items = source.Flatten(x => getChildren(x) ?? []).ToList();
        var itemTasks = items.SelectToArray(x => action(x));

        return Task.WhenAll(itemTasks);
    }

    public static async Task ForEachRecursiveAsync<T>(this T source, Func<T, IEnumerable<T>?> getChildren, Func<T, Task> action)
    {
        var children = getChildren(source);
        if (children is null)
            return;

        await action(source);
        await children.ForEachRecursiveAsync(getChildren, action);
    }

    public static List<T> Flatten<T>(this T source, Func<T, IEnumerable<T>?> getChildren)
    {
        var children = getChildren(source);
        return (children ?? []).Flatten(getChildren).Append(source).ToList();
    }

    public static List<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>?> getChildren)
    {
        return source.SelectMany(c => Flatten(getChildren(c) ?? [], getChildren)).Concat(source).ToList();
    }
}