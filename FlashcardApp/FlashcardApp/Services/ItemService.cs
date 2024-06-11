using FlashcardApp.Common;
using FlashcardApp.Entities;

namespace FlashcardApp.Services;

internal record ItemService(IRepository<Item> Repository)
{
    public async Task<Item[]> GetAll() => await Repository.GetAll();
    public Task<Item> Get(string id) => Repository.GetBy(id);
    public Task<bool> Create(Item entity) => Repository.Create(entity);
    public Task<bool> Update(Item entity) => Repository.Update(entity);
    public Task<bool> Delete(string id) => Repository.Delete(id);
    public async Task<bool> Delete(IEnumerable<string> ids) => (await Task.WhenAll(ids.Select(Repository.Delete).ToArray())).FirstOrDefault();

    public async Task<GetItemsQueryResponse> GetRange(string collectionId, RangeArg range, ModifierArg[]? modifiers = null)
    {
        var itemsAll = await Repository.GetAll();
        var itemsOfCollection = itemsAll.Where(i => i.CollectionId == collectionId).ToArray();

        if (modifiers is not null)
        {
            foreach (var modifier in modifiers)
            {
                if (modifier.Tags is not null and not [])
                    itemsOfCollection = itemsOfCollection.Where(i => i.Tags.Any(modifier.Tags.Contains)).ToArray();
            }
        }

        var itemsRanged = itemsOfCollection.Skip(range.Start).Take(range.Limit).ToArray();

        return new(
            itemsRanged, 
            Range: new(TotalCount: itemsOfCollection.Length, range.Start, range.Limit),
            Tags: itemsAll.SelectMany(i => i.Tags).Distinct().ToArray());
    }
}

public record GetItemsQueryResponse(
    Item[] Items, 
    RangeDTO Range,
    string[] Tags);

public record RangeDTO(
    int TotalCount,
    int Start = 0,
    int Limit = int.MaxValue);

public record RangeArg(
    int Start,
    int Limit);

public record ModifierArg(
    string[]? Tags);