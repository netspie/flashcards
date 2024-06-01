namespace FlashcardApp.Common;

public abstract class Entity : IEntity
{
    public string Id { get; init; }

    public uint Version { get; private set; }

    public Entity() => Id = EntityId.New();
    public Entity(string id) => Id = id;

    public Entity(string id, uint version)
    {
        Id = id;
        Version = version;
    }

    uint IEntity.Version { get => Version; set { Version = value; } }

    public static implicit operator bool(Entity entity) => entity != null;

    public override bool Equals(object? obj)
    {
        if (obj is Entity entity) 
            return Id == entity.Id;
            
        return base.Equals(obj);
    }

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString()
    {
        var result = Id.ToString();

        var type = GetType();
        var nameProperty = type.GetProperty("Name");
        if (nameProperty != null)
        {
            var name = nameProperty.GetValue(this) as string;
            if (name is not null or [])
                result = $"{name} - {Id.ToString()}";
        }

        return result;
    }

    public static string GetRandomName() =>
        $"Item - {new string(Guid.NewGuid().ToString().Take(8).ToArray())}";
}
