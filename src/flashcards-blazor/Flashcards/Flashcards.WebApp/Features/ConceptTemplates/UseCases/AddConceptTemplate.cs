using Mediator;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record AddConceptTemplateCommand(
    string Name,
    ImmutableArray<string> Properties) : ICommand;

public class AddConceptTemplateCommandHandler(
    IConceptTemplateRepository _repository) : ICommandHandler<AddConceptTemplateCommand>
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