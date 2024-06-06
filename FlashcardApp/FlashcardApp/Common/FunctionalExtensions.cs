namespace FlashcardApp.Common;

public static class FunctionalExtensions
{
    public static T? Do<T>(this T? input, Action<T> action)
    {
        if (input is null)
            return default;

        action(input);

        return input;
    }

    public static async Task<bool> Do(this Task<bool> task, Func<Task> action)
    {
        var result = await task;
        if (result)
            await action();

        return result;
    }

    public static async Task<T> DoAsync<T>(this Task<T>? inputTask, Action<T> action)
    {
        if (inputTask is null)
            return default;

        var input = await inputTask;
        if (input is null)
            return default;

        action(input);

        return input;
    }

    public static async Task<TOut> MapAsync<TIn, TOut>(this Task<TIn>? inputTask, Func<TIn, Task<TOut>> action)
    {
        if (inputTask is null)
            return default;

        var input = await inputTask;
        if (input is null)
            return default;

        return await action(input);
    }

    public static async Task<bool> Map<T>(this T? input, Func<T, Task<bool>> action)
    {
        if (input is null)
            return default;

        return await action(input);
    }

    public static TOut Map<TIn, TOut>(this TIn? input, Func<TIn, TOut> mapper)
    {
        if (input is null)
            return default;

        return mapper(input);
    }
}
