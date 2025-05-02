using Mediator;
using MudBlazor;

namespace Flashcards.WebApp.Shared.Spy.Extensions;

public static class SnackbarExtensions
{
    public static async Task Run(this ISnackbar snackbar, Task task)
    {
        await snackbar.Run(Run());
        async ValueTask Run() => await task;
    }

    public static async Task Run(this ISnackbar snackbar, ValueTask<Unit> task) 
    {
        await snackbar.Run(Run());
        async ValueTask Run() => await task;
    }

    public static async Task Run(this ISnackbar snackbar, ValueTask task)
    {
        try
        {
            await task;
            snackbar.Add("Operation successful.", Severity.Success, key: Guid.NewGuid().ToString());
        }
        catch (Exception ex)
        {
            snackbar.Add("Operation failed.", Severity.Error, key: Guid.NewGuid().ToString());
        }
    }
}