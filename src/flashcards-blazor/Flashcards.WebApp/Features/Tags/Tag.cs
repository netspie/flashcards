using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Entities;

namespace Flashcards.WebApp.Features.Tags;

public record Tag(
    TagId Id,
    string Name,
    string Color,
    ProjectId ProjectId,
    TagId? ParentTagId,
    int Order) : IEntity<TagId>, IOrderedItem
{
    IOrderedItem IOrderedItem.ChangeOrder(int order) => this with { Order = order };
}

public record TagId(string Value) : EntityId<TagId>(Value);
