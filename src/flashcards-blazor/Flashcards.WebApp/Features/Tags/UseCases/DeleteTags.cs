using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Tags;

public record DeleteTagsCommand(string[] Ids) : ICommand;

public class DeleteTagsCommandHandler(
    IDeleteOnlyRepository<Tag, TagId> _deleteRepository) : CommandHandler<DeleteTagsCommand>
{
    public override async Task Handle(
        DeleteTagsCommand cmd, CancellationToken ct)
    {
        await _deleteRepository.DeleteMany(TagId.FromStrings(cmd.Ids));
    }
}