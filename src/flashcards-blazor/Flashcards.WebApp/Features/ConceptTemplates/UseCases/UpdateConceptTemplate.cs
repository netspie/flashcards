using Flashcards.WebApp.Shared.Collections;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record UpdateConceptTemplateCommand(
    string Id,
    string Name,
    UpdateConceptTemplateCommand.Property[] Properties) : ICommand
{
    public record Property(string Name);
}

public class UpdateConceptTemplateCommandHandler(
    IReadOnlyRepository<ConceptTemplate, ConceptTemplateId> _readRepository,
    IWriteOnlyRepository<ConceptTemplate, ConceptTemplateId> _writeRepository) : CommandHandler<UpdateConceptTemplateCommand>
{
    public override async Task Handle(
        UpdateConceptTemplateCommand cmd, CancellationToken ct)
    {
        var entity = await _readRepository.GetById(new ConceptTemplateId(cmd.Id));

        entity = entity with 
        { 
            Name = cmd.Name,
            Properties = cmd.Properties.SelectToArray((x, i) => new ConceptTemplate.Property(x.Name, i))
        };

        await _writeRepository.Update(entity);
    }
}