using Flashcards.WebApp.Shared.Collections;

namespace Flashcards.WebApp.Shared.Entities;

public abstract record EntityId<TId>(string Value)
{
    public static TId New()
    {
        var guid = Guid.NewGuid();
        var guidBase64 = guid.ToBase64();

        if (Activator.CreateInstance(typeof(TId), guidBase64) is TId id)
            return id;

        throw new InvalidOperationException($"Cannot create instance of {typeof(TId)}");
    }

    public static TId[] FromStrings(IEnumerable<string> strs) =>
        strs.SelectToArray(x => (TId) Activator.CreateInstance(typeof(TId), x)!);

    public sealed override string ToString() => Value;
}