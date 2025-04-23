using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public class ConceptTemplateInMemoryRepository : IConceptTemplateRepository
{
    private readonly ConcurrentDictionary<ConceptTemplateId, ConceptTemplate> _aliveCache = new();
    private readonly ConcurrentDictionary<ConceptTemplateId, ConceptTemplate> _archivedCache = new();

    public Task<ConceptTemplate> GetById(ConceptTemplateId id, bool includeArchived = false)
    {
        if (includeArchived && _archivedCache.ContainsKey(id))
            throw new InvalidOperationException($"Cannot retrieve entity of {id} id, because it has been archived.");

        if (!_aliveCache.TryGetValue(id, out var conceptTemplate))
            if (!includeArchived || (includeArchived && !_archivedCache.TryGetValue(id, out conceptTemplate)))
                throw new InvalidOperationException($"Cannot retrieve entity of {id} id, because it does not exist.");

        return Task.FromResult(conceptTemplate!);
    }

    public Task<ImmutableArray<ConceptTemplate>> GetMany(LifeState? lifeState = LifeState.Alive) =>
        Task.FromResult(lifeState switch
        {
            LifeState.Alive => _aliveCache.Values.ToImmutableArray(),
            LifeState.Archived => _archivedCache.Values.ToImmutableArray(),
            _ => _aliveCache.Values.Concat(_archivedCache.Values).ToImmutableArray()
        });

    public Task Add(ConceptTemplate conceptTemplate)
    {
        if (_archivedCache.ContainsKey(conceptTemplate.Id))
            throw new InvalidOperationException($"Cannot add entity of {conceptTemplate.Id} id, because it has been archived.");

        if (!_aliveCache.TryAdd(conceptTemplate.Id, conceptTemplate))
            throw new InvalidOperationException($"Cannot add entity of {conceptTemplate.Id} id, because it already exists.");

        return Task.CompletedTask;
    }

    public Task Update(ConceptTemplate conceptTemplate)
    {
        if (_archivedCache.ContainsKey(conceptTemplate.Id))
            throw new InvalidOperationException($"Cannot update entity of {conceptTemplate.Id} id, because it has been archived.");

        if (!_aliveCache.TryGetValue(conceptTemplate.Id, out var prevConceptTemplate))
            throw new InvalidOperationException($"Cannot update entity of {conceptTemplate.Id} id, because it does not exist.");

        if (_aliveCache.TryUpdate(conceptTemplate.Id, conceptTemplate, prevConceptTemplate))
            throw new InvalidOperationException($"Cannot update entity of {conceptTemplate.Id}");

        return Task.CompletedTask;
    }

    public Task Archive(ConceptTemplateId id)
    {
        if (!_aliveCache.TryGetValue(id, out var entity))
            throw new InvalidOperationException($"Cannot archive entity of {id} id, because it does not exist.");

        if (!_archivedCache.TryAdd(id, entity))
            throw new InvalidOperationException($"Cannot archive entity of {id} id, because it has archived been done.");

        _aliveCache.Remove(id, out var _);

        return Task.CompletedTask;
    }

    public Task Restore(ConceptTemplateId id)
    {
        if (_aliveCache.ContainsKey(id))
            throw new InvalidOperationException($"Cannot restore entity of {id} id, because it has not been archived.");

        if (!_archivedCache.TryRemove(id, out var entity))
            throw new InvalidOperationException($"Cannot restore entity of {id} id, because it has not been archived.");

        if (!_aliveCache.TryAdd(id, entity))
            throw new InvalidOperationException($"Cannot restore entity of {id} id, if already exists in the database.");

        return Task.CompletedTask;
    }
}