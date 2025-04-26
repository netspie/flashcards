using Flashcards.WebApp.Shared.EFCore;
using Mediator;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record AddConceptTemplateCommand(
    string Name,
    ImmutableArray<string> Properties) : ICommand;

public class AddConceptTemplateCommandHandler(
    IRepository<ConceptTemplate, ConceptTemplateId> _repository) : ICommandHandler<AddConceptTemplateCommand>
{
    public async ValueTask<Unit> Handle(
        AddConceptTemplateCommand cmd, CancellationToken ct)
    {
        var entity = new ConceptTemplate(
            new ConceptTemplateId(Guid.NewGuid()), cmd.Name, cmd.Properties.ToPropertyArray());

        await _repository.Add(entity);

        return new();
    }
}