using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record AddConceptTemplateCommand(string ProjectId) : ICommand;

public class AddConceptTemplateCommandHandler(
    IWriteOnlyRepository<ConceptTemplate, ConceptTemplateId> _repository) : CommandHandler<AddConceptTemplateCommand>
{
    public override async Task Handle(
        AddConceptTemplateCommand cmd, CancellationToken ct)
    {
        var entity = new ConceptTemplate(
            ConceptTemplateId.New(),
            new ProjectId(cmd.ProjectId),
            Name: "New Concept Template",
            Properties: []);

        await _repository.Add(entity);
    }
}