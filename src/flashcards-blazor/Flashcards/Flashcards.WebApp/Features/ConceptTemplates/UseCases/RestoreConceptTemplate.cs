using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record RestoreConceptTemplateCommand(
    string Id) : ICommand;

public class RestoreConceptTemplateCommandHandler(
    IConceptTemplateRepository _repository) : ICommandHandler<RestoreConceptTemplateCommand>
{
    public async ValueTask<Unit> Handle(
        RestoreConceptTemplateCommand cmd, CancellationToken ct)
    {
        await _repository.Restore(new ConceptTemplateId(Guid.Parse(cmd.Id)));
        return new();
    }
}