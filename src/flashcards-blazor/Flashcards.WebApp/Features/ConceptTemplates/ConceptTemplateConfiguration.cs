using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Flashcards.WebApp.Shared.EntityFrameworkCore;
using Flashcards.WebApp.Features.Projects;

namespace Flashcards.WebApp.Features.ConceptTemplates;

public class ConceptTemplateConfiguration : IEntityTypeConfiguration<ConceptTemplate>
{
    public void Configure(EntityTypeBuilder<ConceptTemplate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne<Project>().WithMany().HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.ProjectId);

        builder.OwnsMany(
            x => x.Properties,
            navBuilder =>
            {
                navBuilder.ToTable("concept_template_properties");
                navBuilder.WithOwner()
                    .HasForeignKey("concept_template_id")
                    .HasConstraintName("fk_concept_template_property_concept_template_id");

                navBuilder.Property(p => p.Name)
                    .HasColumnName("name")
                    .IsRequired();

                navBuilder.HasKey("concept_template_id", nameof(ConceptTemplate.Property.Name));
            });

        builder.Property(x => x.Id).HasStringValueObjectConversion();
        builder.Property(x => x.ProjectId).HasStringValueObjectConversion();
    }
}