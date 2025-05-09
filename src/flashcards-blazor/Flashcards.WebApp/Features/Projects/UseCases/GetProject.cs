using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record GetProjectQuery(string Id) : IQuery<GetProjectQueryResponse>;

public record GetProjectQueryResponse(GetProjectQueryResponse.ProjectDTO Value)
{
    public record ProjectDTO(string Id, string Name);
}

public class GetProjectQueryHandler(
    IReadOnlyRepository<Project, ProjectId> _repository) : IQueryHandler<GetProjectQuery, GetProjectQueryResponse>
{
    public async ValueTask<GetProjectQueryResponse> Handle(
        GetProjectQuery cmd, CancellationToken ct)
    {
        var entity = await _repository.GetById(new ProjectId(cmd.Id));

        return new GetProjectQueryResponse(
            new GetProjectQueryResponse.ProjectDTO(entity.Id.ToString(), entity.Name));
    }
}