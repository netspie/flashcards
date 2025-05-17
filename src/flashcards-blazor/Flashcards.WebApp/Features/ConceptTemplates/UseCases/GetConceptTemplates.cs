using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record GetConceptTemplatesQuery(
    string ProjectId,
    AliveState? LifeState = AliveState.Alive) : IQuery<GetConceptTemplatesQueryResponse>;

public class GetConceptTemplatesQueryHandler(
    IReadOnlyRepository<ConceptTemplate, ConceptTemplateId> _repository) : IQueryHandler<GetConceptTemplatesQuery, GetConceptTemplatesQueryResponse>
{
    public async ValueTask<GetConceptTemplatesQueryResponse> Handle(
        GetConceptTemplatesQuery cmd, CancellationToken ct)
    {
        var projectId = new ProjectId(cmd.ProjectId);
        var entities = await _repository.GetMany(x => x.ProjectId == projectId);

        return new GetConceptTemplatesQueryResponse(
            entities.SelectToArray(x => 
                new GetConceptTemplatesQueryResponse.ConceptTemplate(
                    x.Id.ToString(),
                    x.ProjectId.ToString(),
                    x.Name,
                    x.Properties.SelectToArray(x =>
                        new GetConceptTemplatesQueryResponse.ConceptTemplate.Property(x.Name)))));
    }
}

public record GetConceptTemplatesQueryResponse(GetConceptTemplatesQueryResponse.ConceptTemplate[] Values)
{
    public record ConceptTemplate(string Id, string ProjectId, string Name, ConceptTemplate.Property[] Properties)
    {
        public record Property(string Name);
    }
}
