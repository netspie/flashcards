using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.Expressions;
using Mediator;
using MudBlazor.Charts;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Features.Projects;

public record GetProjectsQuery(
    AliveState? LifeState = AliveState.Alive,
    string UserId = "") : IQuery<GetProjectsQueryResponse>;

public record GetProjectsQueryResponse(GetProjectsQueryResponse.ProjectDTO[] Values)
{
    public record ProjectDTO(string Id, string Name);
}

public class GetProjectsQueryHandler(
    IReadOnlyRepository<Project, ProjectId> _repository) : IQueryHandler<GetProjectsQuery, GetProjectsQueryResponse>
{
    public async ValueTask<GetProjectsQueryResponse> Handle(
        GetProjectsQuery cmd, CancellationToken ct)
    {
        var entities = await _repository.GetMany(
            Filter<Project>.New
                .FilterBy(cmd.UserId)
                .FilterBy(cmd.LifeState));

        return new GetProjectsQueryResponse(
            entities.SelectToArray(x => new GetProjectsQueryResponse.ProjectDTO(x.Id.ToString(), x.Name)));
    }
}