using FlashcardApp.Common;
using FlashcardApp.Entities;

namespace FlashcardApp.Services;

internal record ItemTemplateService(IRepository<ItemTemplate> Repository)
{
    public async Task<ItemTemplate[]> GetAll() => (await Repository.GetAll()).Where(e => !e.IsArchived).ToArray();
    public Task<ItemTemplate> Get(string id) => Repository.GetBy(id);
    public Task<bool> Create(ItemTemplate entity) => Repository.Create(entity);
    public Task<bool> Update(ItemTemplate entity) => Repository.Update(entity);
    public Task<bool> Delete(string id) =>
        Repository
            .GetBy(id)
            .DoAsync(e => e.IsArchived = true)
            .MapAsync(Repository.Update);
}
