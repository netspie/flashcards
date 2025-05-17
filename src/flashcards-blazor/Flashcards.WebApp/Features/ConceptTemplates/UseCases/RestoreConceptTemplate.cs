using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record RestoreConceptTemplateCommand(
    string Id) : ICommand;

public class RestoreConceptTemplateCommandHandler(
    IArchiveRepository<ConceptTemplate, ConceptTemplateId> _repository) : CommandHandler<RestoreConceptTemplateCommand>
{
    public override async Task Handle(
        RestoreConceptTemplateCommand cmd, CancellationToken ct)
    {
        await _repository.Restore(new ConceptTemplateId(cmd.Id));
    }
}