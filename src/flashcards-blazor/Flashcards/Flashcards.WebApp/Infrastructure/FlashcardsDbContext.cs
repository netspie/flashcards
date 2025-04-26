using Flashcards.WebApp.Features.ConceptTemplates;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Infrastructure;

public class FlashcardsDbContext(
    DbContextOptions<FlashcardsDbContext> _options, IConfiguration _configuration) : DbContext(_options)
{
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("FlashcardsDb");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlashcardsDbContext).Assembly);
    }

    public DbSet<ConceptTemplate> ConceptTemplates { get; set; }
}