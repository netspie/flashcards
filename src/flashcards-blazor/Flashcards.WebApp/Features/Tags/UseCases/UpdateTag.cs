using Flashcards.WebApp.Shared;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Tags;

public record UpdateTagCommand(
    string Id,
    string Name,
    string Color,
    int Order = int.MaxValue) : ICommand;

public class UpdateTagCommandHandler(
    IReadOnlyRepository<Tag, TagId> _readRepository,
    IWriteOnlyRepository<Tag, TagId> _writeRepository) : CommandHandler<UpdateTagCommand>
{
    public override Task Handle(
        UpdateTagCommand cmd, CancellationToken ct) =>
        _readRepository
            .GetById(new TagId(cmd.Id))
            .MapAsync(e => e with { Name = cmd.Name, Order = cmd.Order, Color = cmd.Color })
            .MapAsync(e =>
                _writeRepository.UpdateOrderedItem(
                    e,
                    _readRepository,
                    filterNeighbours: x => x.ProjectId == e.ProjectId && x.ParentTagId == e.ParentTagId));
}