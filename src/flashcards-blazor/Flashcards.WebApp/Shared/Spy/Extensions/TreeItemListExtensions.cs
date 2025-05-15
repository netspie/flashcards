using MudBlazor;

namespace Flashcards.WebApp.Shared.Spy.Extensions;

public static class TreeItemListExtensions
{
    public  static List<TTreeItem> GetTreeItems<TTreeItem, TDTO>(
        this IEnumerable<TDTO> dtos,
        Func<TDTO, string> getId,
        Func<TDTO, string?> getParentId,
        Func<TDTO, string> getName,
        Func<TDTO?, int?> getOrder,
        Func<TDTO, TTreeItem> createTreeItem)
        where TTreeItem : TreeItemData<TDTO>, new()
    {
        var treeItems = new List<TTreeItem>();

        var map = new Dictionary<string, TTreeItem>();

        foreach (var dto in dtos)
        {
            var id = getId(dto);

            if (!map.TryGetValue(id, out var treeItem))
                map.Add(id, treeItem = createTreeItem(dto));

            if (treeItem.Value is null)
            {
                var children = treeItem.Children;
                treeItem = createTreeItem(dto);
                treeItem.Children = children;
            }

            treeItem.Text = getName(dto);

            var parentId = getParentId(dto);
            if (parentId is not null)
            {
                if (!map.TryGetValue(parentId, out var parent))
                    map.Add(parentId, parent = new());

                parent.Children ??= new();
                parent.Children.Add(treeItem);
                parent.Children = parent.Children.OrderBy(x => getOrder(x.Value) ?? 0).ToList();
            }
            else
            {
                treeItems.Add(treeItem);
                treeItems = treeItems.OrderBy(x => getOrder(x.Value) ?? 0).ToList();
            }
        }

        return treeItems;
    }
}
