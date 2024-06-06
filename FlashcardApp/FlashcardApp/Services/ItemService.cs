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
}
