using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flashcards.WebApp.Shared.EntityFrameworkCore;

public static class PropertyBuilderExtensions
{
    public static ValueConverter<TId, string> GuidIdToStringConverter<TId>() =>
        new(id => id.GetType().GetProperty("Value").GetValue(id).ToString(),
            str => (TId)Activator.CreateInstance(typeof(TId), Guid.Parse(str)));

    public static PropertyBuilder<T> HasEntityIdGuidConversion<T>(this PropertyBuilder<T> builder) =>
        builder.HasConversion(GuidIdToStringConverter<T>());
}