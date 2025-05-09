using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record ArchiveProjectCommand(
    string Id) : ICommand;

public class ArchiveProjectCommandHandler(
    IArchiveRepository<Project, ProjectId> _repository) : CommandHandler<ArchiveProjectCommand>
{
    public override async Task Handle(
        ArchiveProjectCommand cmd, CancellationToken ct)
    {
        await _repository.Archive(ProjectId.FromGuidString(cmd.Id));
    }
}