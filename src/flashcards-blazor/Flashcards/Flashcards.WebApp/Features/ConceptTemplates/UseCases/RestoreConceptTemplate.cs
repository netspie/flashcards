using Flashcards.WebApp.Shared.EFCore;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record RestoreConceptTemplateCommand(
    string Id) : ICommand;

public class RestoreConceptTemplateCommandHandler(
    IRepository<ConceptTemplate, ConceptTemplateId> _repository) : ICommandHandler<RestoreConceptTemplateCommand>
{
    public async ValueTask<Unit> Handle(
        RestoreConceptTemplateCommand cmd, CancellationToken ct)
    {
        await _repository.Restore(new ConceptTemplateId(Guid.Parse(cmd.Id)));
        return new();
    }
}