using Mediator;

namespace Flashcards.WebApp.Shared.UseCases;

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
        var behaviours = _serviceProvider.GetServices<IMessageTransmuter<IRequest<TResponse>>>();
        foreach (var behaviour in behaviours)
            request = await behaviour.Handle(request, cancellationToken);

        using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(request, cancellationToken);
    }

    public async ValueTask<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        var behaviours = _serviceProvider.GetServices<IMessageTransmuter<ICommand<TResponse>>>();
        foreach (var behaviour in behaviours)
            command = await behaviour.Handle(command, cancellationToken);

        using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(command, cancellationToken);
    }

    public async ValueTask<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var behaviours = _serviceProvider.GetServices<IMessageTransmuter<IQuery<TResponse>>>();
        foreach (var behaviour in behaviours)
            query = await behaviour.Handle(query, cancellationToken);

        using var scope = _scopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(query, cancellationToken);
    }
}
