using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Collections;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Features.Tags;

public record GetProjectTagsQuery(
    string ProjectId) : IQuery<GetProjectTagsQueryResponse>;

public record GetProjectTagsQueryResponse(GetProjectTagsQueryResponse.ProjectTagDTO[] Values)
{
    public record ProjectTagDTO(string Id, string Name, string? ParentTagId);
}

public class GetProjectTagsQueryHandler(
    DbContext context) : IQueryHandler<GetProjectTagsQuery, GetProjectTagsQueryResponse>
{
    public async ValueTask<GetProjectTagsQueryResponse> Handle(
        GetProjectTagsQuery cmd, CancellationToken ct)
    {
        var projectId = new ProjectId(cmd.ProjectId);
        var projectTags = await context.Set<Tag>()
            .AsNoTracking()
            .Where(x => x.ProjectId == projectId)
            .ToArrayAsync();

        return new GetProjectTagsQueryResponse(
            projectTags.SelectToArray(x => new GetProjectTagsQueryResponse.ProjectTagDTO(
                x.Id.ToString(), x.Name, x.ParentTagId?.ToString())));
    }
}   