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
}
