using Flashcards.WebApp.Shared.Entities;
using Mediator;

namespace Flashcards.WebApp.Features.Tags;

public record DeleteTagsCommand(string[] Ids) : ICommand;

public class DeleteTagsCommandHandler(
    IDeleteOnlyRepository<Tag, TagId> _deleteRepository) : ICommandHandler<DeleteTagsCommand>
{
    public async ValueTask<Unit> Handle(
        DeleteTagsCommand cmd, CancellationToken ct)
    {
        await _deleteRepository.DeleteMany(TagId.FromGuidStrings(cmd.Ids));

        return new();
    }
}