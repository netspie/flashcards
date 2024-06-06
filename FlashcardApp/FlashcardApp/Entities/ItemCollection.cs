using FlashcardApp.Common;

namespace FlashcardApp.Entities;

public class ItemCollection(string? name = null, string? defaultItemTemplateId = null) : Entity
{
    public string Name { get; set; } = name ?? "New Collection";
    public string? DefaultItemTemplateId { get; set; } = defaultItemTemplateId;
    public bool IsArchived { get; set; }
}
