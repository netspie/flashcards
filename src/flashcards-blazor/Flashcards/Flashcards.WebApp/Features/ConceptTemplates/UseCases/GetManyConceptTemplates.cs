using Mediator;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record GetManyConceptTemplatesQuery(
    LifeState? LifeState = LifeState.Alive) : IQuery<GetManyConceptTemplatesResponse>;

public record GetManyConceptTemplatesResponse(ImmutableArray<ConceptTemplateDTO> Values);

public record ConceptTemplateDTO(
    string Id,
    string Name,
    ImmutableArray<string> Properties);

public class GetManyConceptTemplatesQueryHandler(
    IConceptTemplateRepository _repository) : IQueryHandler<GetManyConceptTemplatesQuery, GetManyConceptTemplatesResponse>
{
    public async ValueTask<GetManyConceptTemplatesResponse> Handle(
        GetManyConceptTemplatesQuery cmd, CancellationToken ct)
    {
        var entities = await _repository.GetMany(cmd.LifeState);

        return new GetManyConceptTemplatesResponse(
            entities
                .Select(x => new ConceptTemplateDTO(x.Id.Value.ToString(), x.Name, x.Properties))
                .ToImmutableArray());
    }
}