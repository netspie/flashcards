using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Entities;

namespace Flashcards.WebApp.Features.Tags;

public record Tag(
    TagId Id,
    string Name,
    ProjectId ProjectId,
    TagId? ParentTagId,
    int Order) : IOrdered
{
    IOrdered IOrdered.ChangeOrder(int order) => this with { Order = order };
}

public record TagId(Guid Value) : GuidEntityId<TagId>(Value);