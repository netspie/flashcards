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
                navBuilder.ToTable("concept_template_properties");
                navBuilder.WithOwner()
                    .HasForeignKey("concept_template_id")
                    .HasConstraintName("fk_concept_template_property_concept_template_id");

                navBuilder.Property(p => p.Value)
                    .HasColumnName("value")
                    .IsRequired();

                navBuilder.HasKey("concept_template_id", nameof(ConceptTemplate.Property.Value) );
            });

        // add datetime fields
    }
}