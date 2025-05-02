using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.DDD;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record GetProjectsQuery(
    LifeState? LifeState = LifeState.Alive,
    string UserId = "") : IQuery<GetProjectsQueryResponse>;

public record GetProjectsQueryResponse(ProjectDTO[] Values);

public record ProjectDTO(
    string Id,
    string Name);

public class GetManyProjectsQueryHandler(
    IRepository<Project, ProjectId> _repository) : IQueryHandler<GetProjectsQuery, GetProjectsQueryResponse>
{
    public async ValueTask<GetProjectsQueryResponse> Handle(
        GetProjectsQuery cmd, CancellationToken ct)
    {
        var entities = await _repository.GetMany(cmd.LifeState, cmd.UserId);

        return new GetProjectsQueryResponse(
            entities.SelectToArray(x => new ProjectDTO(x.Id.Value.ToString(), x.Name)));
    }
}