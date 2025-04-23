using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public interface IConceptTemplateRepository
{
    Task<ConceptTemplate> GetById(ConceptTemplateId id, bool includeArchived = false);
    Task<ImmutableArray<ConceptTemplate>> GetMany(LifeState? lifeState = LifeState.Alive);

    Task Add(ConceptTemplate conceptTemplate);
    Task Update(ConceptTemplate conceptTemplate);

    Task Archive(ConceptTemplateId id);
    Task Restore(ConceptTemplateId id);
}

public enum LifeState
{
    Alive,
    Archived,
}