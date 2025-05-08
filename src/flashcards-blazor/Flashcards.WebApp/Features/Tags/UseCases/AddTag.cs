using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Entities;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Features.Tags;

public record AddTagCommand(
    string Name,
    string ProjectId,
    string? ParentTagId = null,
    int Order = int.MaxValue) : ICommand;

public class AddTagCommandHandler(
    IWriteOnlyRepository<Tag, TagId> _repository,
    DbContext _context) : ICommandHandler<AddTagCommand>
{
    public async ValueTask<Unit> Handle(
        AddTagCommand cmd, CancellationToken ct)
    {
        var entity = new Tag(
            TagId.New(), 
            cmd.Name, 
            ProjectId.FromGuidString(cmd.ProjectId),
            cmd.ParentTagId is not null ? TagId.FromGuidString(cmd.ParentTagId) : null,
            cmd.Order);

        if (cmd.Order != int.MaxValue)
            _context.Set<Tag>().Where(x => x.Order >= cmd.Order);

        await _repository.Add(entity);

        return new();
    }
}