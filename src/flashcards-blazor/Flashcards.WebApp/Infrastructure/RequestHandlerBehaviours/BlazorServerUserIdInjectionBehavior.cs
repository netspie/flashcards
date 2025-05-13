using Flashcards.WebApp.Shared.UseCases;
using Mediator;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Flashcards.WebApp.Infrastructure.RequestHandlerBehaviours;

public class BlazorServerUserIdInjectionBehavior<TRequest>(
    AuthenticationStateProvider _authenticationStateProvider) : IMessageTransmuter<TRequest>
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
    IUnitOfWork _unitOfWork) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
{
    public async ValueTask<TResponse> Handle(
        TRequest message, CancellationToken ct, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        

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
