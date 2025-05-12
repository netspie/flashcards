using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Collections;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Features.Tags;

public record GetProjectTagsQuery(
    string ProjectId) : IQuery<GetProjectTagsQueryResponse>;

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
                x.Id.ToString(), 
                x.Name, 
                x.ParentTagId?.ToString(),
                x.Color,
                x.Order)));
    }
}

public record GetProjectTagsQueryResponse(GetProjectTagsQueryResponse.ProjectTagDTO[] Values)
{
    public record ProjectTagDTO
    {
        public ProjectTagDTO() {}
        public ProjectTagDTO(string id, string name, string? parentTagId, string color, int order)
        {
            Id = id;
            Name = name;
            ParentTagId = parentTagId;
            Color = color;
            Order = order;
        }

        public ProjectTagDTO DeepCopy() => new(Id, Name, ParentTagId, Color, Order);

        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? ParentTagId { get; set; }
        public string Color { get; set; } = "";
        public int Order { get; set; }
    }
}