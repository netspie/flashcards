using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record GetProjectQuery(string Id) : IQuery<GetProjectQueryResponse>;

public record GetProjectQueryResponse(GetProjectQueryResponse.ProjectDTO Value)
{
    public record ProjectDTO(string Id, string Name);
}

public class GetProjectQueryHandler(
    IRepository<Project, ProjectId> _repository) : IQueryHandler<GetProjectQuery, GetProjectQueryResponse>
{
    public async ValueTask<GetProjectQueryResponse> Handle(
        GetProjectQuery cmd, CancellationToken ct)
    {
        var entity = await _repository.GetById(ProjectId.FromGuidString(cmd.Id));

        return new GetProjectQueryResponse(
            new GetProjectQueryResponse.ProjectDTO(entity.Id.Value.ToString(), entity.Name));
    }
}