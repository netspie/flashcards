using Flashcards.WebApp.Shared.DDD;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record AddProjectCommand(
    string Name,
    string UserId = "") : ICommand;

public class AddProjectCommandHandler(
    IRepository<Project, ProjectId> _repository) : ICommandHandler<AddProjectCommand>
{
    public async ValueTask<Unit> Handle(
            AddProjectCommand cmd, CancellationToken ct)
    {
        var entity = new Project(
            new ProjectId(Guid.NewGuid()), cmd.Name, cmd.UserId);

        await _repository.Add(entity);

        return new();
    }
}