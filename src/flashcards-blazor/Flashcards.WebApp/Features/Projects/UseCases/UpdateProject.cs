using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record UpdateProjectCommand(
    string Id,
    string Name) : ICommand;

public class UpdateProjectCommandHandler(
    IReadOnlyRepository<Project, ProjectId> _readRepository,
    IWriteOnlyRepository<Project, ProjectId> _writeRepository) : CommandHandler<UpdateProjectCommand>
{
    public override async Task Handle(
        UpdateProjectCommand cmd, CancellationToken ct)
    {
        var entity = await _readRepository.GetById(new ProjectId(cmd.Id));
        entity = entity with { Name = cmd.Name };
        await _writeRepository.Update(entity);
    }
}