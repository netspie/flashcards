using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Features.Tags;
using Flashcards.WebApp.Infrastructure.RequestHandlerBehaviours;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.EntityFrameworkCore;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Features;

public static class FlashcardsStartup
{
    public static IServiceCollection AddFlashcards(this IServiceCollection services)
    {
        services.AddScoped<IReadOnlyRepository<Project, ProjectId>, DbContextReadOnlyRepository<Project, ProjectId>>();
        services.AddScoped<IWriteOnlyRepository<Project, ProjectId>, DbContextWriteOnlyRepository<Project, ProjectId>>();
        services.AddScoped<IArchiveRepository<Project, ProjectId>, DbContextArchiveRepository<Project, ProjectId>>();

        services.AddScoped<IRepository<Tag, TagId>>(sp =>
        {
            var context = sp.GetRequiredService<DbContext>();
            return new OrderedEntityRepositoryDecorator(
                context,
                new DbContextRepository<Tag, TagId>(context));
        });
            
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(BlazorServerUserIdInjectionBehavior<,>));

        return services;
    }
}
