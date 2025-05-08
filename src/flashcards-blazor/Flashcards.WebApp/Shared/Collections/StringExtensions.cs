namespace Flashcards.WebApp.Shared.Collections;

public static class StringExtensions
{
    public static T? NullIfEmpty<T>(this T value) =>
        value is string ? value : default;
}
