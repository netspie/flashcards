namespace Flashcards.WebApp.Shared.Collections;

public static class EnumerableExtensions
{
    public static TOut[] SelectToArray<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> mapper) =>
        source.Select(mapper).ToArray();

    public static TOut[] SelectToArray<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, int, TOut> mapper) =>
        source.Select(mapper).ToArray();

    public static List<T> CastToList<T>(this IEnumerable<object> source) =>
        source.Cast<T>().ToList();

    public static List<T>? CastToListOrDefault<T>(this IEnumerable<object>? source) =>
        source?.Cast<T>()?.ToList();
}
