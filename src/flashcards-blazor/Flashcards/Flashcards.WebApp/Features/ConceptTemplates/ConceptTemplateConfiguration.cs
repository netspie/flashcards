using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flashcards.WebApp.Features.ConceptTemplates;

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

        // add datetime fields
    }
}