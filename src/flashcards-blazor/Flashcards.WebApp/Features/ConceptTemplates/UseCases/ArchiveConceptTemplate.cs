using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ArchiveConceptTemplateCommand(
    string Id) : ICommand;

public class ArchiveConceptTemplateCommandHandler(
    IArchiveRepository<ConceptTemplate, ConceptTemplateId> _repository) : CommandHandler<ArchiveConceptTemplateCommand>
{
    public override async Task Handle(
        ArchiveConceptTemplateCommand cmd, CancellationToken ct)
    {
        await _repository.Archive(new ConceptTemplateId(cmd.Id));
    }
}