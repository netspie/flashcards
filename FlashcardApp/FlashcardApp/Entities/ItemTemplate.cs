using FlashcardApp.Common;
using static FlashcardApp.Entities.FlashcardTemplate.Side;

namespace FlashcardApp.Entities;

public class ItemTemplate : Entity
{
    public required string Name { get; set; } = "New Item Template";
    public List<Field> Fields { get; init; } = [];
    public List<FlashcardTemplate> FlashcardTemplates { get; init; } = [];
    public bool IsArchived { get; set; } = false;

    public bool AddField(string name)
    {
        if (Fields.Any(f => f.Name == name))
            return false;

        Fields.Add(new Field { Name = name });

        return true;
    }

    public void RenameField(string fieldId, string name) =>
        Fields
            .FirstOrDefault(f => f.Id == fieldId)
            .Do(f => f.Name = name);

    public void MoveField(string fieldId, int dir)
    {
        var i = Fields.FindIndex(ft => ft.Id == fieldId);
        var f = Fields;

        (f[i], f[i + dir]) = (f[i + dir], f[i]);
    }

    public void RemoveField(string fieldId) =>
        Fields.RemoveAt(
            Fields.FindIndex(ft => ft.Id == fieldId));

    public void AddFlashcardTemplate(string name) =>
        FlashcardTemplates.Add(new(name));

    public void RemoveFlashcardTemplate(string id) =>
        FlashcardTemplates.RemoveAt(
            FlashcardTemplates.FindIndex(ft => ft.Id == id));

    public void RenameFlashcardTemplate(string id, string name) =>
        FlashcardTemplates
            .FirstOrDefault(ft => ft.Id == id)
            .Do(ft => ft.Name = name);

    public void MoveFlashcardTemplate(string id, int dir)
    {
        var i = FlashcardTemplates.FindIndex(ft => ft.Id == id);
        var f = FlashcardTemplates;

        (f[i], f[i + dir]) = (f[i+dir], f[i]);
    }

    public void AddAllFlashcardTemplateSideFields(string flashcardTemplateId, int sideIndex)
    {
        var fieldIds = GetFlashcardTemplate(flashcardTemplateId)
            .Sides[sideIndex]
            .FieldIds;

        var allFieldIds = Fields.Select(f => f.Id).Except(fieldIds).ToArray();

        fieldIds.AddRange(allFieldIds);
    }

    public bool AddFlashcardTemplateSideField(string flashcardTemplateId, int sideIndex, string fieldId)
    {
        if (!Fields.Any(f => f.Id == fieldId))
            return false;

        var fieldIds = GetFlashcardTemplate(flashcardTemplateId)
            .Sides[sideIndex]
            .FieldIds;

        if (fieldIds.Contains(fieldId))
            return false;

        fieldIds.Add(fieldId);

        return true;
    }

    public bool MoveFlashcardTemplateSideField(string flashcardTemplateId, int sideIndex, string fieldId, int dir)
    {
        if (!Fields.Any(f => f.Id == fieldId))
            return false;

        var f = GetFlashcardTemplate(flashcardTemplateId).Sides[sideIndex].FieldIds;
        var i = f.FindIndex(id => id == fieldId);

        (f[i], f[i + dir]) = (f[i + dir], f[i]);

        return true;
    }

    public bool RemoveFlashcardTemplateSideField(string flashcardTemplateId, int sideIndex, string fieldId)
    {
        if (!Fields.Any(f => f.Id == fieldId))
            return false;

        var f = GetFlashcardTemplate(flashcardTemplateId).Sides[sideIndex].FieldIds;
        return f.Remove(fieldId);
    }

    private FlashcardTemplate GetFlashcardTemplate(string flashcardTemplateId) =>
        FlashcardTemplates.FirstOrDefault(ft => ft.Id == flashcardTemplateId);
}

public class FlashcardTemplate(string name = "New Flashcard Template")
{
    public string Id { get; init; } = new string(Guid.NewGuid().ToString().Take(6).ToArray());
    public string Name { get; set; } = name;
    public List<Side> Sides { get; init; } = [];

    public record Side
    {
        public string Name { get; set; } = "New Side";
        public List<string> FieldIds { get; init; } = [];

        public record Field
        {
            public string Id { get; init; } = new string(Guid.NewGuid().ToString().Take(6).ToArray());

            public string Name { get; set; } = "New Field";
        }
    }
}
