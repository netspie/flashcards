using FlashcardApp.Common;
using FlashcardApp.Entities;

namespace FlashcardApp.Services;

public record ItemCollectionService(IRepository<ItemCollection> Repository)
{
    public async Task<ItemCollection[]> GetAll() => (await Repository.GetAll()).Where(e => !e.IsArchived).ToArray();
    public Task<ItemCollection> Get(string id) => Repository.GetBy(id);
    public Task<bool> Create(ItemCollection entity) => Repository.Create(entity);
    public Task<bool> Update(ItemCollection entity) => Repository.Update(entity);
    public Task<bool> Delete(string id) =>
        Repository
            .GetBy(id)
            .DoAsync(e => e.IsArchived = true)
            .MapAsync(Repository.Update);
}
