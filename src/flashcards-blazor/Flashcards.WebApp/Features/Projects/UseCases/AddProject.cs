using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Projects;

public record AddProjectCommand(
    string Name,
    string UserId = "") : ICommand;

public class AddProjectCommandHandler(
    IWriteOnlyRepository<Project, ProjectId> _repository) : CommandHandler<AddProjectCommand>
{
    public override async Task Handle(
        AddProjectCommand cmd, CancellationToken ct)
    {
        var entity = new Project(ProjectId.New(), cmd.Name, cmd.UserId);
        await _repository.Add(entity);
    }
}