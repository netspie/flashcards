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

    public async Task<(Item[] items, RangeDTO range)> GetRange(string collectionId, RangeArg range, ModifierArg[]? modifiers = null)
    {
        //var dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FlashcardApp/items";
        var items = await Repository.GetAll();
        var itemsRanged = items.Skip(range.Start).Take(range.Limit).ToArray();

        return (itemsRanged, new(items.Length, range.Start, range.Limit));
    }
}

public record RangeDTO(
    int TotalCount,
    int Start = 0,
    int Limit = int.MaxValue);

public record RangeArg(
    int Start,
    int Limit);

public record ModifierArg(
    string[]? Tags);