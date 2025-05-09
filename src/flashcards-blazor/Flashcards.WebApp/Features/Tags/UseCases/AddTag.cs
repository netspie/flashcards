using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.Expressions;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Tags;

public record AddTagCommand(
    string Name,
    string ProjectId,
    string? ParentTagId = null,
    int Order = int.MaxValue) : ICommand;

public class AddTagCommandHandler(
    IReadOnlyRepository<Tag, TagId> _readRepository,
    IWriteOnlyRepository<Tag, TagId> _writeRepository) : CommandHandler<AddTagCommand>
{
    public override async Task Handle(
        AddTagCommand cmd, CancellationToken ct)
    {
        var entity = new Tag(
            TagId.New(), 
            cmd.Name, 
            ProjectId.FromGuidString(cmd.ProjectId),
            cmd.ParentTagId is not null ? TagId.FromGuidString(cmd.ParentTagId) : null,
            cmd.Order);

        await _writeRepository.AddOrderedItem(entity, _readRepository, x => x.ProjectId == entity.ProjectId);
    }
}