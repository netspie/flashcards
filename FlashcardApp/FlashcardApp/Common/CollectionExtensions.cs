namespace FlashcardApp.Common;

public static class EnumerableExtensions
{
    public static int IndexWhere<T>(this IEnumerable<T> source, Func<T, bool> condition)
    {
        if (source is null)
            return -1;

        var len = source.Count();
        int i = 0;

        foreach (var item in source)
        {
            if (condition(item))
                return i;

            i++;
        }

        return -1;
    }
}
