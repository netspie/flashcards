using FlashcardApp.Common;

namespace FlashcardApp.Entities;

public class ItemTemplate : Entity
{
    public required string Name { get; init; } = "New Item Template";
    public List<string> Fields { get; init; } = [];
    public bool Archived { get; set; } = false;
}
