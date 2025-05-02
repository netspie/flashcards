using System.Collections.Immutable;

namespace Flashcards.WebApp.Shared.Collections;

public static class EnumerableExtensions
{
    public static ImmutableArray<TOut> SelectToImmutableArray<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> mapper) =>
        source.Select(mapper).ToImmutableArray();
}