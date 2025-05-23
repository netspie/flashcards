﻿using Flashcards.WebApp.Shared.EFCore;
using Mediator;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ArchiveConceptTemplateCommand(
    string Id) : ICommand;

public class ArchiveConceptTemplateCommandHandler(
    IRepository<ConceptTemplate, ConceptTemplateId> _repository) : ICommandHandler<ArchiveConceptTemplateCommand>
{
    public async ValueTask<Unit> Handle(
        ArchiveConceptTemplateCommand cmd, CancellationToken ct)
    {
        await _repository.Archive(new ConceptTemplateId(Guid.Parse(cmd.Id)));
        return new();
    }
}