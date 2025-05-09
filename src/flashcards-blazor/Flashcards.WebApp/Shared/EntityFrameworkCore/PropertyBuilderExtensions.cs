using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<T> HasStringValueObjectConversion<T>(this PropertyBuilder<T> builder) =>
        builder.HasConversion(
            id => (string) typeof(T).GetProperty("Value")!.GetValue(id)!,
            str => (T) Activator.CreateInstance(typeof(T), str)!);
}