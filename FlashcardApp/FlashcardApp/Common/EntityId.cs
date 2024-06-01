namespace FlashcardApp.Common;

public abstract class EntityId
{
    public string Value { get; init; }

    public EntityId(string value) => Value = value;

    public static string New() => Guid.NewGuid().ToString();
    public bool IsValid() => Guid.TryParse(Value, out var id);
    public override string ToString() => Value;
    public override bool Equals(object? obj)
    {
        if (obj is EntityId entityId) 
            return entityId.Value == Value;

        return base.Equals(obj);
    }

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(EntityId left, EntityId right)
        => left is null || right is null ? false : left.Equals(right);

    public static bool operator !=(EntityId left, EntityId right)
       => left is null || right is null ? true : !left.Equals(right);

    public static implicit operator string(EntityId entityId) => entityId.Value;
}
