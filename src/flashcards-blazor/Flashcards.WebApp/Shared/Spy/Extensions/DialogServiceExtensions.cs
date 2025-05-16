using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Flashcards.WebApp.Shared.Spy.Extensions;

public static class DialogServiceExtensions
{
    public static async Task<bool> ShowAndGetSubmittedAsync<T>(this IDialogService dialogService, string title)
        where T : IComponent
    {
        var dialog = await dialogService.ShowAsync<T>(title);
        var result = await dialog.Result;

        return result?.Canceled is false;
    }
}