using MudBlazor;

namespace Flashcards.WebApp.Shared.Spy.Extensions;

public static class TreeItemListExtensions
{
    public  static List<TTreeItem> GetTreeItems<TTreeItem, TDTO>(
        this IEnumerable<TDTO> dtos,
        Func<TDTO, string> getId,
        Func<TDTO, string?> getParentId,
        Func<TDTO?, int?> getOrder,
        Func<TDTO, TTreeItem> createTreeItem)
        where TTreeItem : TreeItemData<TDTO>, new()
    {
        var map = new Dictionary<string, TTreeItem>();

        foreach (var dto in dtos)
        {
            var id = getId(dto);

            if (!map.TryGetValue(id, out var treeItem))
                map.Add(id, treeItem = createTreeItem(dto));

            if (treeItem.Value is null)
            {
                var children = treeItem.Children;
                map[id] = createTreeItem(dto);
                map[id].Children = children;
            }

            var parentId = getParentId(dto);
            if (parentId is not null)
            {
                if (!map.TryGetValue(parentId, out var parent))
                    map.Add(parentId, parent = new());

                parent.Children ??= new();
                parent.Children.Add(treeItem);
                parent.Children = parent.Children.OrderBy(x => getOrder(x.Value) ?? 0).ToList();
            }
        }

        var treeItems = map.Values.Where(x => x.Value is not null ? getParentId(x.Value) is null : false).ToList();
        return treeItems.OrderBy(x => getOrder(x.Value)).ToList();
    }
}