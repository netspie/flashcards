namespace Flashcards.WebApp.Shared;

public static class TaskExtensions
{
    public static async ValueTask ToValueTask(this Task? task)
    {
        if (task is not null)
            await task;
    }
}