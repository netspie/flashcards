using System.Diagnostics.CodeAnalysis;

namespace Flashcards.WebApp.Shared;

public static class FunctionalExtensions
{
    public static TOut Map<TOut>(this object source) where TOut : new() =>
        new TOut();

    public static TOut Map<TIn, TOut>(this TIn source, TOut value) =>
        value;

    public static (T1, T2) Join<T1, T2>(this T1 source, Func<T1, T2> joiner) =>
        (source, joiner(source));

    public static (T1, T2, T3) Join<T1, T2, T3>(this (T1, T2) source, Func<T1, T2, T3> joiner) =>
        (source.Item1, source.Item2, joiner(source.Item1, source.Item2));

    public static (TIn, TOut) Map<TIn, TOut>(this TIn source, Func<TIn, (TIn, TOut)> extender)
    {
        return extender(source);
    }

    public static (T1, TOut) MapLast<T1, T2, TOut>(this (T1, T2) source, Func<T1, T2, TOut> mapper)
    {
        var result = mapper(source.Item1, source.Item2);
        return (source.Item1, result);
    }

    public static (T1, T2, TOut) MapLast<T1, T2, T3, TOut>(this (T1, T2, T3) source, Func<T1, T2, T3, TOut> mapper)
    {
        var result = mapper(source.Item1, source.Item2, source.Item3);
        return (source.Item1, source.Item2, result);
    }

    public static TOut Map<T1, T2, TOut>(this (T1, T2) source, Func<T1, T2, TOut> mapper)
    {
        return mapper(source.Item1, source.Item2);
    }

    public static TOut Map<TIn, TOut>(this TIn source, Func<TOut> mapper)
    {
        return mapper();
    }

    public static TOut Map<TIn, TOut>(this TIn source, Func<TIn, TOut> mapper)
    {
        return mapper(source);
    }

    public static async Task<TOut> MapAsync<TIn, TOut>(this Task<TIn> source, Func<TIn, TOut> mapper) =>
        mapper(await source);

    public static async Task<TOut> MapAsync<T1, T2, TOut>(this (T1, Task<T2>) source, Func<T1, T2, TOut> mapper)
    {
        var item2 = await source.Item2;
        return mapper(source.Item1, item2);
    }

    public static Task<TOut> MapAsync<TOut>(this Task source) where TOut : new() =>
        Task.FromResult(new TOut());

    public static async Task<(T1, TOut)> MapLastAsync<T1, T2, TOut>(this (T1, Task<T2>) source, Func<T1, T2, TOut> mapper)
    {
        var item2 = await source.Item2;
        var itemLast = mapper(source.Item1, item2);

        return (source.Item1, itemLast);
    }

    public static async Task<(T1, TOut)> MapLastAsync<T1, T2, TOut>(this (T1, T2) source, Func<T1, T2, Task<TOut>> mapper)
    {
        var itemLast = mapper(source.Item1, source.Item2);
        return (source.Item1, await itemLast);
    }

    public static async Task<(T1, T2, TOut)> MapLastAsync<T1, T2, T3, TOut>(this (T1, T2, Task<T3>) source, Func<T1, T2, T3, TOut> mapper)
    {
        var item3 = await source.Item3;
        var itemLast = mapper(source.Item1, source.Item2, item3);

        return (source.Item1, source.Item2, itemLast);
    }

    public static T IO<T>(this T source, Action action)
    {
        action();
        return source;
    }

    public static async Task<(T1, T2)> IOAsync<T1, T2>(this (T1, Task<T2>) source, Action<T1, T2> action)
    {
        var item2 = await source.Item2;
        action(source.Item1, item2);

        return (source.Item1, item2);
    }

    public static async Task<(T1, T2)> IOAsync<T1, T2>(this Task<(T1, T2)> sourceTask, Action<T1, T2> action)
    {
        var source = await sourceTask;
        action(source.Item1, source.Item2);
        return (source.Item1, source.Item2);
    }

    public static async Task<(T1, T2, T3)> IOAsync<T1, T2, T3>(this Task<(T1, T2, T3)> sourceTask, Action<T1, T2, T3> action)
    {
        var source = await sourceTask;
        action(source.Item1, source.Item2, source.Item3);
        return (source.Item1, source.Item2, source.Item3);
    }

    public static async Task<(T1, T2, T3)> IOAsync<T1, T2, T3>(this Task<(T1, T2, T3)> sourceTask, Action<T1, T2> action)
    {
        var source = await sourceTask;
        action(source.Item1, source.Item2);
        return (source.Item1, source.Item2, source.Item3);
    }

    public static async Task<(T1, T2)> IOAsync<T1, T2>(this Task<(T1, T2)> sourceTask, Action action)
    {
        var source = await sourceTask;
        action();
        return (source.Item1, source.Item2);
    }

    public static async Task<(T1, T2, T3)> IOAsync<T1, T2, T3>(this Task<(T1, T2, T3)> sourceTask, Action action)
    {
        var source = await sourceTask;
        action();
        return (source.Item1, source.Item2, source.Item3);
    }

    public static async Task<(T1, T2, T3)> IOAsync<T1, T2, T3>(this (T1, T2, Task<T3>) source, Action<T1, T2, T3> action)
    {
        action(source.Item1, source.Item2, await source.Item3);
        return (source.Item1, source.Item2, await source.Item3);
    }

    public static T ThrowIf<T>(this T source, Func<T, bool> throwIf, Func<Exception> exception) =>
        throwIf(source) ? source : throw exception();

    public static (T1, T2) ThrowIf<T1, T2>(this (T1, T2?) source, Func<T1, T2?, bool> throwIf, Func<Exception> exception) =>
        throwIf(source.Item1, source.Item2) ? 
            (source.Item1, source.Item2) : 
            throw exception();

    public static async Task<(T1, T2)> ThrowIfAsync<T1, T2>(this (T1, ValueTask<T2?>) source, Func<T1, T2?, bool> throwIf, Func<Exception> exception)
    {
        var item2 = await source.Item2;
        if (item2 is null)
            throw new ArgumentNullException();

        if (throwIf(source.Item1, item2))
            throw exception();

        return (source.Item1, item2);
    }

    public static TOut MapOrThrowIf<TIn, TOut>(this TIn source, Func<TIn, TOut> mapper, Func<TIn, bool> throwIf, Func<Exception> exception)
    {
        var shouldThrow = throwIf(source);
        if (shouldThrow)
            throw exception();

        return mapper(source);
    }
}
