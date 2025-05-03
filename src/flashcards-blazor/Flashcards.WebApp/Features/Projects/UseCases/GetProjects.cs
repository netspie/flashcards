using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record GetProjectsQuery(
    AliveState? LifeState = AliveState.Alive,
    string UserId = "") : IQuery<GetProjectsQueryResponse>;

public record GetProjectsQueryResponse(GetProjectsQueryResponse.ProjectDTO[] Values)
{
    public record ProjectDTO(string Id, string Name);
}

public class GetProjectsQueryHandler(
    IRepository<Project, ProjectId> _repository) : IQueryHandler<GetProjectsQuery, GetProjectsQueryResponse>
{
    public async ValueTask<GetProjectsQueryResponse> Handle(
        GetProjectsQuery cmd, CancellationToken ct)
    {
        var entities = await _repository.GetMany(cmd.LifeState, cmd.UserId);

        return new GetProjectsQueryResponse(
            entities.SelectToArray(x => new GetProjectsQueryResponse.ProjectDTO(x.Id.Value.ToString(), x.Name)));
    }
}