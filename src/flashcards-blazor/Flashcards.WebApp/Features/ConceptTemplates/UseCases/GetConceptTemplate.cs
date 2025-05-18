using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record GetConceptTemplateQuery(string Id) : IQuery<GetConceptTemplateQueryResponse>;

public record GetConceptTemplateQueryResponse(GetConceptTemplateQueryResponse.ConceptTemplate Value)
{
    public record ConceptTemplate(string Id, string ProjectId, string Name, ConceptTemplate.Property[] Properties)
    {
        public static readonly ConceptTemplate Default = new("", "", "", []);
        public record Property(string Name);
    }
}

public class GetConceptTemplateQueryHandler(
    IReadOnlyRepository<ConceptTemplate, ConceptTemplateId> _repository) : IQueryHandler<GetConceptTemplateQuery, GetConceptTemplateQueryResponse>
{
    public async ValueTask<GetConceptTemplateQueryResponse> Handle(
        GetConceptTemplateQuery cmd, CancellationToken ct)
    {
        var entity = await _repository.GetById(new ConceptTemplateId(cmd.Id));

        return new GetConceptTemplateQueryResponse(
            new GetConceptTemplateQueryResponse.ConceptTemplate(
                entity.Id.ToString(),
                entity.ProjectId.ToString(),
                entity.Name,
                entity.Properties.SelectToArray(x => 
                    new GetConceptTemplateQueryResponse.ConceptTemplate.Property(
                        x.Name))));
    }
}