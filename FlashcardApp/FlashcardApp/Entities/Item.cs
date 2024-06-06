using FlashcardApp.Common;

namespace FlashcardApp.Entities;

public class Item : Entity
{
    public Item() {}
    public Item(string id) : base(id) {}

    public required string CollectionId { get; set; }
    public string? ItemTemplateId { get; set; }

    public List<Field>? Fields { get; init; } = [];

    public record Field(string Id, string Name, string Value);
}
