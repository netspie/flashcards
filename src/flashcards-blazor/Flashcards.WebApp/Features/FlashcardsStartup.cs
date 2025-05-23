﻿using Flashcards.WebApp.Features.ConceptTemplates;
using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Features.Tags;
using Flashcards.WebApp.Infrastructure.MessageTransmuters;
using Flashcards.WebApp.Infrastructure.RequestHandlerBehaviors;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.EntityFrameworkCore;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features;

public static class FlashcardsStartup
{
    public static IServiceCollection AddFlashcards(this IServiceCollection services)
    {
        services.AddMediator(opts => opts.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddScoped<IScopedMediator, AsyncScopedMediator>();

        services.AddScoped(typeof(IMessageTransmuter<>), typeof(BlazorServerMessageUserIdTransmuter<>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DbContextTransactionBehavior<,>));

        services.AddScoped<IReadOnlyRepository<Project, ProjectId>, DbContextReadOnlyRepository<Project, ProjectId>>();
        services.AddScoped<IWriteOnlyRepository<Project, ProjectId>, DbContextWriteOnlyRepository<Project, ProjectId>>();
        services.AddScoped<IArchiveRepository<Project, ProjectId>, DbContextArchiveRepository<Project, ProjectId>>();

        services.AddScoped<IReadOnlyRepository<Tag, TagId>, DbContextReadOnlyRepository<Tag, TagId>>();
        services.AddScoped<IWriteOnlyRepository<Tag, TagId>, DbContextWriteOnlyRepository<Tag, TagId>>();
        services.AddScoped<IDeleteOnlyRepository<Tag, TagId>, DbContextDeleteOnlyRepository<Tag, TagId>>();

        services.AddScoped<IReadOnlyRepository<ConceptTemplate, ConceptTemplateId>, DbContextReadOnlyRepository<ConceptTemplate, ConceptTemplateId>>();
        services.AddScoped<IWriteOnlyRepository<ConceptTemplate, ConceptTemplateId>, DbContextWriteOnlyRepository<ConceptTemplate, ConceptTemplateId>>();
        services.AddScoped<IArchiveRepository<ConceptTemplate, ConceptTemplateId>, DbContextArchiveRepository<ConceptTemplate, ConceptTemplateId>>();

        return services;
    }
}