using Flashcards.WebApp.Features.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Flashcards.WebApp.Features.Projects;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value.ToString(),
                value => new ProjectId(Guid.Parse(value)))
            .ValueGeneratedNever();

        //ConversionExtensions.GuidIdToStringConverter<ProjectId>();
        //ConversionExtensions.StringToGuidIdConverter<ProjectId>());

        builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}

public static class ConversionExtensions
{
    public static Expression<Func<TId, string>> GuidIdToStringConverter<TId>() =>
        (TId id) => id.GetType().GetProperty("Value").GetValue(id) as string;

    public static Expression<Func<string, TId>> StringToGuidIdConverter<TId>() =>
        (string idValue) => (TId) Activator.CreateInstance(typeof(TId), Guid.Parse(idValue));
}