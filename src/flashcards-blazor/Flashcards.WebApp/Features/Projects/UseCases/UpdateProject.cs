using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record UpdateProjectCommand(
    string Id,
    string Name) : ICommand;

public class UpdateProjectCommandHandler(
    IRepository<Project, ProjectId> _repository) : ICommandHandler<UpdateProjectCommand>
{
    public async ValueTask<Unit> Handle(
        UpdateProjectCommand cmd, CancellationToken ct)
    {
        var entity = await _repository.GetById(ProjectId.FromGuidString(cmd.Id));

        entity = entity with { Name = cmd.Name };

        await _repository.Update(entity);

        return new();
    }
}