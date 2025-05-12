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

        var neighboursCount = await readRepository.Count(filterNeighbours);
        var itemOrder = Math.Clamp(item.Order, 0, neighboursCount);
        item = (T) item.ChangeOrder(itemOrder);

        var neighourItems = await readRepository.GetMany(filterNeighbours.And(x => x.Order > item.Order));

        var reorderedEntities = neighourItems.Select((x, i) => (T) x.ChangeOrder(item.Order + i + 1));

        await writeRepository.UpdateMany(reorderedEntities);
        await writeRepository.Add(item);
    }

    public static async Task UpdateOrderedItem<T, TId>(
        this IWriteOnlyRepository<T, TId> writeRepository,
        T item,
        IReadOnlyRepository<T, TId> readRepository,
        Expression<Func<T, bool>>? filterNeighbours = null) where T : IOrderedItem, IEntity<TId>
    {
        filterNeighbours ??= Filter<T>.New;

        var neighboursCount = await readRepository.Count(filterNeighbours);
        var itemOrder = Math.Clamp(item.Order, 0, neighboursCount);
        item = (T) item.ChangeOrder(itemOrder);

        var neighourItems = await readRepository.GetMany(filterNeighbours.And(x => x.Order >= item.Order).And(x => !x.Id.Equals(item.Id)));
        
        var reorderedEntities = neighourItems
            .Select((x, i) => (T) x.ChangeOrder(item.Order + i + 1))
            .Append(item)
            .ToArray();

        await writeRepository.UpdateMany(reorderedEntities);
    }
}