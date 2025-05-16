using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Tags;

public record DeleteTagsCommand(string[] Ids) : ICommand;

public class DeleteTagsCommandHandler(
    IReadOnlyRepository<Tag, TagId> _readRepository,
    IWriteOnlyRepository<Tag, TagId> _writeRepository,
    IDeleteOnlyRepository<Tag, TagId> _deleteRepository) : CommandHandler<DeleteTagsCommand>
{
    public override async Task Handle(
        DeleteTagsCommand cmd, CancellationToken ct)
    {
        var tagIds = TagId.FromStrings(cmd.Ids);
        var tags = await _readRepository.GetMany(x => tagIds.Contains(x.Id));

        if (tags.DistinctBy(x => x.ParentTagId).Count() > 1)
            throw new InvalidOperationException("Cannot delete tags from multiple parents at once");

        var parentTagId = tags.First().ParentTagId;

        await _deleteRepository.DeleteOrderedItems(
            _writeRepository, _readRepository, tagIds,
            filterNeighbors: x =>  x.ParentTagId == parentTagId);
    }
}