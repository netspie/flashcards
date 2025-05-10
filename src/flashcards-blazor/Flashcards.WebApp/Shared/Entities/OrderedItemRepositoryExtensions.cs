using Flashcards.WebApp.Shared.Expressions;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public static class OrderedItemRepositoryExtensions
{
    public static async Task AddOrderedItem<T, TId>(
        this IWriteOnlyRepository<T, TId> writeRepository,
        T item,
        IReadOnlyRepository<T, TId> readRepository,
        Expression<Func<T, bool>>? filterNeighbours = null) where T : IOrderedItem
    {
        filterNeighbours ??= Filter<T>.New;

        var neighourItems = await readRepository.GetMany(filterNeighbours.And(x => x.Order > item.Order));

        var reorderedEntities = neighourItems.Select((x, i) => (T) x.ChangeOrder(item.Order + i + 1));

        await writeRepository.UpdateMany(reorderedEntities);
        await writeRepository.Update(item);
    }

    public static async Task UpdateOrderedItem<T, TId>(
        this IWriteOnlyRepository<T, TId> writeRepository,
        T item,
        IReadOnlyRepository<T, TId> readRepository,
        Expression<Func<T, bool>>? filterNeighbours = null) where T : IOrderedItem
    {
        filterNeighbours ??= Filter<T>.New;

        var neighourItems = await readRepository.GetMany(filterNeighbours.And(x => x.Order > item.Order));

        var reorderedEntities = neighourItems
            .Select((x, i) => (T) x.ChangeOrder(item.Order + i + 1))
            .Append(item);

        await writeRepository.UpdateMany(reorderedEntities);
    }
}