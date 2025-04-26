using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Immutable;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public record ConceptTemplate(
    ConceptTemplateId Id,
    string Name,
    ImmutableArray<ConceptTemplate.Property> Properties)
{
    public ConceptTemplate() : this(
        new ConceptTemplateId(Guid.NewGuid()), 
        Name: "",
        Properties: []) { }

    public record Property(string Value)
    {
        public static implicit operator Property(string Value) => new(Value);
    }
}

public static class ConceptTemplateExtensions
{
    public static ImmutableArray<ConceptTemplate.Property> ToPropertyArray(this IEnumerable<string> properties) =>
        properties.Select(x => new ConceptTemplate.Property(x)).ToImmutableArray();

    public static ImmutableArray<string> ToStringArray(this IEnumerable<ConceptTemplate.Property> properties) =>
        properties.Select(x => x.Value).ToImmutableArray();
}

public readonly record struct ConceptTemplateId(Guid Value)
{
    public override string ToString() => Value.ToString();
}

public class ConceptTemplateConfiguration : IEntityTypeConfiguration<ConceptTemplate>
{
    public void Configure(EntityTypeBuilder<ConceptTemplate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value.ToString(),
                value => new ConceptTemplateId(Guid.Parse(value)))
            .ValueGeneratedNever();

        builder.Property(x => x.Name).IsRequired();

        builder.OwnsMany(
            x => x.Properties,
            navBuilder =>
            {
                navBuilder.ToTable("ConceptTemplateProperties");
                navBuilder.WithOwner().HasForeignKey(nameof(ConceptTemplateId));

                navBuilder.Property(p => p.Value)
                    .HasColumnName("Value")
                    .IsRequired();

                navBuilder.HasKey("ConceptTemplateId", "Value");
            });
    }
}