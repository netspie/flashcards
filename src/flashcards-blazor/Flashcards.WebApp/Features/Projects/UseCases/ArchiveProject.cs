using Flashcards.WebApp.Shared.DDD;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record ArchiveProjectCommand(
    string Id) : ICommand;

public class ArchiveProjectCommandHandler(
    IRepository<Project, ProjectId> _repository) : ICommandHandler<ArchiveProjectCommand>
{
    public async ValueTask<Unit> Handle(
        ArchiveProjectCommand cmd, CancellationToken ct)
    {
        await _repository.Archive(new ProjectId(Guid.Parse(cmd.Id)));
        return new();
    }
}