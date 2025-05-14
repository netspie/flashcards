using Flashcards.WebApp.Shared.Expressions;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public static class OrderedItemRepositoryExtensions
{
    public static async Task AddOrderedItem<T, TId>(
        this IWriteOnlyRepository<T, TId> writeRepository,
        T item,
        IReadOnlyRepository<T, TId> readRepository,
        Expression<Func<T, bool>>? filterNeighbours = null) where T : IOrderedItem, IEntity<TId>
    {
        filterNeighbours ??= Filter<T>.New;

        var neighbours = await readRepository.GetMany(filterNeighbours.And(x => !x.Id.Equals(item.Id)));
        var itemOrder = Math.Clamp(item.Order, 0, neighbours.Length);
        item = (T) item.ChangeOrder(itemOrder);

        var itemList = neighbours.OrderBy(x => x.Order).ToList();
        itemList.Insert(itemOrder, item);

        var reorderedEntities = itemList
            .Where(x => !x.Id.Equals(item.Id))
            .Select((x, i) => (T) x.ChangeOrder(i))
            .ToArray();

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

        var neighours = await readRepository.GetMany(filterNeighbours.And(x => !x.Id.Equals(item.Id)));
        var itemOrder = Math.Clamp(item.Order, 0, neighours.Length);

        var itemList = neighours.OrderBy(x => x.Order).ToList();
        itemList.Insert(itemOrder, item);
        
        var reorderedEntities = itemList
            .Select((x, i) => (T) x.ChangeOrder(i))
            .ToArray();

        await writeRepository.UpdateMany(reorderedEntities);
    }
}