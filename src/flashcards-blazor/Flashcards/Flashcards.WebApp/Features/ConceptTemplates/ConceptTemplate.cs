using Flashcards.WebApp.Shared.Collections;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ConceptTemplate(
    ConceptTemplateId Id,
    string Name,
    IEnumerable<ConceptTemplate.Property> Properties)
{
    public ConceptTemplate() : this(
        new ConceptTemplateId(Guid.NewGuid()), 
        Name: "",
        Properties: []) { }

    public record Property(string Value)
    {
        public static implicit operator Property(string Value) => new(Value);
    }
}

public static class ConceptTemplateExtensions
{
    public static ImmutableArray<ConceptTemplate.Property> ToPropertyArray(this IEnumerable<string> properties) =>
        properties.SelectToImmutableArray(x => new ConceptTemplate.Property(x));

    public static ImmutableArray<string> ToStringArray(this IEnumerable<ConceptTemplate.Property> properties) =>
        properties.SelectToImmutableArray(x => x.Value);
}

public readonly record struct ConceptTemplateId(Guid Value)
{
    public override string ToString() => Value.ToString();
}
