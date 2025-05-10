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
    public override async Task Handle(
        UpdateTagCommand cmd, CancellationToken ct)
    {
        var entity = await _readRepository.GetById(new TagId(cmd.Id));
        entity = entity with { Name = cmd.Name, Order = cmd.Order, Color = cmd.Color };
        await _writeRepository.UpdateOrderedItem(entity, _readRepository, x => x.ProjectId == entity.ProjectId);
    }
}