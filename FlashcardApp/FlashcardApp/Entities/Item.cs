using FlashcardApp.Common;

namespace FlashcardApp.Entities;

public class Item : Entity
{
    public DateTime CreatedTime { get; init; } = DateTime.UtcNow;

    public required string CollectionId { get; set; }
    public string? ItemTemplateId { get; set; }

    public List<Field>? Fields { get; init; } = [];

    public List<string> Tags { get; init; } = [];

    public Item() {}
    public Item(string id) : base(id) {}

    public bool AddTag(string tag)
    {
        tag = tag.Trim();
        if (Tags.Contains(tag))
            return false;

        Tags.Add(tag);

        return true;
    }

    public bool RemoveTag(string tag) =>
        Tags.Remove(tag);

    public record Field(string Id, string Name, string Value);
}
