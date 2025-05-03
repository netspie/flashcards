using MudBlazor;

namespace Flashcards.WebApp.Features.Projects;

public class TagTreeItemData : TreeItemData<string>
{
    public Color IconColor { get; set; }

    public TagTreeItemData(string text, Color color) : base(text)
    {
        Text = text;
        IconColor = color;
        Icon = Icons.Material.Filled.Bookmark;
    }

    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple,
        Black,
        White,
        Gray,
        Brown,
        Pink,
        Cyan,
        Magenta
    }
}

public static class TailwindColorExtensions
{
    public static string ToTailwindHex(this TagTreeItemData.Color color) =>
        color switch
        {
            TagTreeItemData.Color.Red => "#ef4444", // red-500
            TagTreeItemData.Color.Green => "#22c55e", // green-500
            TagTreeItemData.Color.Blue => "#3b82f6", // blue-500
            TagTreeItemData.Color.Yellow => "#eab308", // yellow-500
            TagTreeItemData.Color.Orange => "#f97316", // orange-500
            TagTreeItemData.Color.Purple => "#a855f7", // purple-500
            TagTreeItemData.Color.Black => "#000000", // no Tailwind black-500, using black
            TagTreeItemData.Color.White => "#ffffff", // white
            TagTreeItemData.Color.Gray => "#6b7280", // gray-500
            TagTreeItemData.Color.Brown => "#78350f", // using amber-900 as closest to brown
            TagTreeItemData.Color.Pink => "#ec4899", // pink-500
            TagTreeItemData.Color.Cyan => "#06b6d4", // cyan-500
            TagTreeItemData.Color.Magenta => "#d946ef", // fuchsia-500 (closest match to magenta)
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
}