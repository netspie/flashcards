using Mediator;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record UpdateConceptTemplateCommand(
    string Id,
    string Name,
    ImmutableArray<string> Properties) : ICommand;

public class UpdateConceptTemplateCommandHandler(
    IConceptTemplateRepository _repository) : ICommandHandler<UpdateConceptTemplateCommand>
{
    public async ValueTask<Unit> Handle(
        UpdateConceptTemplateCommand cmd, CancellationToken ct)
    {
        var entity = await _repository.GetById(new ConceptTemplateId(Guid.Parse(cmd.Id)));

        entity = entity with 
        {
            Name = cmd.Name,
            Properties = cmd.Properties.ToPropertyArray(),
        };

        await _repository.Update(entity);

        return new();
    }
}