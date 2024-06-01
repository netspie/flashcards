using FlashcardApp.Common;
using FlashcardApp.Entities;

namespace FlashcardApp.Services;

internal record ItemTemplateService(IRepository<ItemTemplate> Repository)
{
    public Task<ItemTemplate[]> GetAll() => Repository.GetAll();
    public Task<ItemTemplate> Get(string id) => Repository.GetBy(id);
    public Task<bool> Create(ItemTemplate entity) => Repository.Create(entity);
    public Task<bool> Update(ItemTemplate entity) => Repository.Update(entity);
    public Task<bool> Delete(string id) => Repository.Delete(id);
}
