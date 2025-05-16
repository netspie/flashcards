using Flashcards.WebApp.Shared.Expressions;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Shared.Entities;

public static class OrderedItemRepositoryExtensions
{
    public static async Task AddOrderedItem<T, TId>(
        this IWriteOnlyRepository<T, TId> writeRepository,
        T item,
        IReadOnlyRepository<T, TId> readRepository,
        Expression<Func<T, bool>>? filterNeighbors = null) where T : IOrderedItem, IEntity<TId>
    {
        filterNeighbors ??= Filter<T>.New;

        var neighbors = await readRepository.GetMany(filterNeighbors.And(x => !x.Id.Equals(item.Id)));
        var itemOrder = Math.Clamp(item.Order, 0, neighbors.Length);
        item = (T) item.ChangeOrder(itemOrder);

        var itemList = neighbors.OrderBy(x => x.Order).ToList();
        itemList.Insert(itemOrder, item);

        var reorderedEntities = itemList
            .Select((x, i) => (T) x.ChangeOrder(i))
            .ToList();

        item = reorderedEntities.First(x => x.Id.Equals(item.Id));
        reorderedEntities = reorderedEntities.Where(x => !x.Id.Equals(item.Id)).ToList();

        await writeRepository.Add(item);
        await writeRepository.UpdateMany(reorderedEntities);
    }

    public static async Task UpdateOrderedItem<T, TId>(
        this IWriteOnlyRepository<T, TId> writeRepository,
        T item,
        IReadOnlyRepository<T, TId> readRepository,
        Expression<Func<T, bool>>? filterNeighbors = null) where T : IOrderedItem, IEntity<TId>
    {
        filterNeighbors ??= Filter<T>.New;

        var oldItem = await readRepository.GetById(item.Id);
        if (oldItem.Order == item.Order)
        {
            await writeRepository.Update(item);
            return;
        }

        var neighbors = await readRepository.GetMany(filterNeighbors.And(x => !x.Id.Equals(item.Id)));
        var itemOrder = Math.Clamp(item.Order, 0, neighbors.Length);

        var itemList = neighbors.OrderBy(x => x.Order).ToList();
        itemList.Insert(itemOrder, item);
        
        var reorderedEntities = itemList
            .Select((x, i) => (T) x.ChangeOrder(i))
            .ToArray();

        await writeRepository.UpdateMany(reorderedEntities);
    }

    public static async Task DeleteOrderedItems<T, TId>(
        this IDeleteOnlyRepository<T, TId> deleteRepository,
        IWriteOnlyRepository<T, TId> writeRepository,
        IReadOnlyRepository<T, TId> readRepository,
        TId[] itemIds,
        Expression<Func<T, bool>>? filterNeighbors = null) where T : IOrderedItem, IEntity<TId>
    {
        filterNeighbors ??= Filter<T>.New;

        var neighbors = await readRepository.GetMany(filterNeighbors.And(x => !itemIds.Contains(x.Id)));

        var itemList = neighbors.OrderBy(x => x.Order).ToList();

        var reorderedEntities = itemList
            .Select((x, i) => (T) x.ChangeOrder(i))
            .ToArray();

        await deleteRepository.DeleteMany(itemIds);
        await writeRepository.UpdateMany(reorderedEntities);
    }
}