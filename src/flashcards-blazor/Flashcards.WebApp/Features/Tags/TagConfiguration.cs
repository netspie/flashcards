using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flashcards.WebApp.Features.Tags;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne<Tag>().WithMany().HasForeignKey(x => x.ParentTagId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<Project>().WithMany().HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjectId);

        builder.Property(x => x.Id).HasEntityIdGuidConversion();
        builder.Property(x => x.ProjectId).HasEntityIdGuidConversion();
        builder.Property(x => x.ParentTagId).HasEntityIdGuidConversion();
    }
}