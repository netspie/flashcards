using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Entities;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ConceptTemplate(
    ConceptTemplateId Id,
    ProjectId ProjectId,
    string Name,
    IEnumerable<ConceptTemplate.Property> Properties,
    bool IsArchived = false) : IEntity<ConceptTemplateId>, IArchived
{
    public record Property(string Name, int Order)
    {
        public static implicit operator Property(string Name) => new(Name);
    }
}

public record ConceptTemplateId(string Value) : EntityId<ConceptTemplateId>(Value);