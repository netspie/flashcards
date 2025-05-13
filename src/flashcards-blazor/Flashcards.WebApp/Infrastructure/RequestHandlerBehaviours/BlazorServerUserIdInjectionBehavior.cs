using Mediator;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Flashcards.WebApp.Infrastructure.RequestHandlerBehaviours;

public interface IPreSendBehavior<TMessage> where TMessage : notnull, IMessage
{
    ValueTask<TMessage> Handle(
        TMessage message,
        CancellationToken cancellationToken);
}

public class BlazorServerUserIdInjectionBehavior<TRequest>(
    AuthenticationStateProvider _authenticationStateProvider) : IPreSendBehavior<TRequest>
    where TRequest : IMessage
{
    public async ValueTask<TRequest> Handle(
        TRequest message, CancellationToken ct)
    {
        var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userId = authenticationState.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var userIdProperty = message.GetType().GetProperty("UserId");
        userIdProperty?.SetValue(message, userId);

        return message;
    }
}

public class UnitOfWorkBehavior<TRequest, TResponse>(
    //IDbContextFactory<ApplicationDbContext> _contextFactory,
    //DbContextProvider _contextProvider,
    IServiceProvider _serviceProvider) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IMessage
{
    public async ValueTask<TResponse> Handle(
        TRequest message, CancellationToken ct, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        //var context = _contextFactory.CreateDbContext();

        using var scope = _serviceProvider.CreateAsyncScope();
        using var scope2 = scope.ServiceProvider.CreateAsyncScope();
        //scope.ServiceProvider.sc
        return await next(message, ct);
    }
}

public interface IDbContextProvider
{

}

public class DbContextProvider
{
    public DbContext Context { get; set; }
}

public interface IRepositoryFactory
{
    TRepository Create<TRepository>();
}

public interface IScopedMediator
{
    ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    ValueTask<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    ValueTask<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}

public class AsyncScopedMediator(
    IServiceScopeFactory _scopeFactory,
    IServiceProvider _serviceProvider) : IScopedMediator
{
    public async ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var behaviours = _serviceProvider.GetServices<IPreSendBehavior<IRequest<TResponse>>>();
        foreach (var behaviour in behaviours)
            request = await behaviour.Handle(request, cancellationToken);

        using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(request, cancellationToken);
    }

    public async ValueTask<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        var behaviours = _serviceProvider.GetServices<IPreSendBehavior<ICommand<TResponse>>>();
        foreach (var behaviour in behaviours)
            command = await behaviour.Handle(command, cancellationToken);

        using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(command, cancellationToken);
    }

    public async ValueTask<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var behaviours = _serviceProvider.GetServices<IPreSendBehavior<IQuery<TResponse>>>();
        foreach (var behaviour in behaviours)
            query = await behaviour.Handle(query, cancellationToken);

        using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(query, cancellationToken);
    }
}