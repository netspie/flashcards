using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ArchiveConceptTemplateCommand(
    string Id) : ICommand;

public class ArchiveConceptTemplateCommandHandler(
    IConceptTemplateRepository _repository) : ICommandHandler<ArchiveConceptTemplateCommand>
{
    public async ValueTask<Unit> Handle(
        ArchiveConceptTemplateCommand cmd, CancellationToken ct)
    {
        await _repository.Archive(new ConceptTemplateId(Guid.Parse(cmd.Id)));
        return new();
    }
}