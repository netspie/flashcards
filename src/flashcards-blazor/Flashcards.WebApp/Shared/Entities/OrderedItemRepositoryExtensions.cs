using Flashcards.WebApp.Features.Tags;
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
}