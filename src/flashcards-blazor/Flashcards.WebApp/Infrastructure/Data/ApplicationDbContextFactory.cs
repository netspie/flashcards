using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Infrastructure.Data;

public class ApplicationDbContextFactory(
    DbContextOptions<ApplicationDbContext> _options,
    IConfiguration _configuration) : IDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext() =>
        new ApplicationDbContext(_options, _configuration);
}