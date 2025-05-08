namespace Flashcards.WebApp.Shared.Entities;

public record GuidEntityId<TId>(Guid Value)
{
    public static TId New()
    {
        if (Activator.CreateInstance(typeof(TId), Guid.NewGuid()) is TId id)
            return id;

        throw new InvalidOperationException($"Cannot create instance of {typeof(TId)}");
    }

    public static TId FromGuidString(string guidStr)
    {
        if (Activator.CreateInstance(typeof(TId), Guid.Parse(guidStr)) is TId id)
            return id;

        throw new InvalidOperationException($"Cannot create instance of {typeof(TId)}");
    }

    public override string ToString() => Value.ToString();
}