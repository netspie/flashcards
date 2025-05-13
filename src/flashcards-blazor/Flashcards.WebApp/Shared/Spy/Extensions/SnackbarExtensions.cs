using Mediator;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq.Expressions;
using System.Reflection;

namespace Flashcards.WebApp.Shared.Spy.Extensions;

public static class SnackbarExtensions
{
    public static async Task Run(this ISnackbar snackbar, Func<ValueTask> task) 
    {
        await snackbar.Run(async Task () => await task());
    }

    public static async Task<T?> Run<T>(this ISnackbar snackbar, Func<ValueTask<T>> task)
    {
        return await snackbar.Run(async Task<T> () => await task());
    }

    public static async Task Run(this ISnackbar snackbar, Func<Task> task)
    {
        try
        {
            await task();
            snackbar.Add("Operation successful.", Severity.Success, key: Guid.NewGuid().ToString());
        }
        catch (Exception ex)
        {
            snackbar.Add(ex.ToString(), Severity.Error, key: Guid.NewGuid().ToString());
        }
    }

    public static async Task<T?> Run<T>(this ISnackbar snackbar, Func<Task<T>> task)
    {
        try
        {
            var result = await task();
            snackbar.Add("Operation successful.", Severity.Success, key: Guid.NewGuid().ToString());
            return result;
        }
        catch (Exception ex)
        {
            snackbar.Add(ex.ToString(), Severity.Error, key: Guid.NewGuid().ToString());
        }

        return default;
    }
}