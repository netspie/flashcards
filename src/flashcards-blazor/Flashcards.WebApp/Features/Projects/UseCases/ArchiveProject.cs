using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record ArchiveProjectCommand(
    string Id) : ICommand;

public class ArchiveProjectCommandHandler(
    IArchiveRepository<Project, ProjectId> _repository) : ICommandHandler<ArchiveProjectCommand>
{
    public async ValueTask<Unit> Handle(
        ArchiveProjectCommand cmd, CancellationToken ct)
    {
        await _repository.Archive(ProjectId.FromGuidString(cmd.Id));
        return new();
    }
}