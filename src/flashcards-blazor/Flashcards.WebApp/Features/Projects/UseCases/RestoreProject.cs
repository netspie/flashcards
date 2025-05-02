using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record RestoreProjectCommand(
    string Id) : ICommand;

public class RestoreProjectCommandHandler(
    IRepository<Project, ProjectId> _repository) : ICommandHandler<RestoreProjectCommand>
{
    public async ValueTask<Unit> Handle(
        RestoreProjectCommand cmd, CancellationToken ct)
    {
        await _repository.Restore(new ProjectId(Guid.Parse(cmd.Id)));
        return new();
    }
}