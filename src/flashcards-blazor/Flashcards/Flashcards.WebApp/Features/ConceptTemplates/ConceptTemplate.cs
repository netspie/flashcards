using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ConceptTemplate(
    ConceptTemplateId Id,
    string Name,
    ImmutableArray<string> Properties);

public readonly record struct ConceptTemplateId(Guid Value)
{
    public override string ToString() => Value.ToString();
}