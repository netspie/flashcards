using FlashcardApp.Common;

namespace FlashcardApp.Entities;

public class ItemTemplate : Entity
{
    public string Name { get; set; } = "New Item Template";
    public List<string> Fields { get; init; } = [];
}
