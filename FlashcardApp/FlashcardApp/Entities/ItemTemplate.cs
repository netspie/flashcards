using FlashcardApp.Common;

namespace FlashcardApp.Entities;

public class ItemTemplate : Entity
{
    public required string Name { get; set; } = "New Item Template";
    public List<string> Fields { get; init; } = [];
    public List<FlashcardTemplate> FlashcardTemplates { get; init; } = [];
    public bool Archived { get; set; } = false;

    public void AddFlashcardTemplate(string name) =>
        FlashcardTemplates.Add(new(name));

    public void RemoveFlashcardTemplate(string id) =>
        FlashcardTemplates.RemoveAt(
            FlashcardTemplates.FindIndex(ft => ft.Id == id));

    public void RenameFlashcardTemplate(string id, string name) =>
        FlashcardTemplates.FirstOrDefault(ft => ft.Id == id).Name = name;

    public void MoveFlashcardTemplate(string id, int dir)
    {
        var i = FlashcardTemplates.FindIndex(ft => ft.Id == id);
        var f = FlashcardTemplates;

        (f[i], f[i + dir]) = (f[i+dir], f[i]);
    }
}

public class FlashcardTemplate(string name = "New Flashcard Template")
{
    public string Id { get; set; } = new string(Guid.NewGuid().ToString().Take(6).ToArray());
    public string Name { get; set; } = name;
    public List<Side> Sides { get; init; } = [];

    public record Side()
    {
        public List<string> Fields { get; init; } = [];
    }
}
