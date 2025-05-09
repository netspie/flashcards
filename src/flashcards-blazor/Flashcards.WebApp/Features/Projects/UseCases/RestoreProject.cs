using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record RestoreProjectCommand(
    string Id) : ICommand;

public class RestoreProjectCommandHandler(
    IArchiveRepository<Project, ProjectId> _repository) : CommandHandler<RestoreProjectCommand>
{
    public override async Task Handle(
        RestoreProjectCommand cmd, CancellationToken ct)
    {
        await _repository.Restore(ProjectId.FromGuidString(cmd.Id));
    }
}