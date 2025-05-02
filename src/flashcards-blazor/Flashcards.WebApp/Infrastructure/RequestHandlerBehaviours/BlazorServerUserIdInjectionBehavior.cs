using Mediator;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Flashcards.WebApp.Infrastructure.RequestHandlerBehaviours;

public class BlazorServerUserIdInjectionBehavior<TRequest, TResponse>(
    AuthenticationStateProvider _authenticationStateProvider) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IMessage
{
    public async ValueTask<TResponse> Handle(
        TRequest message, CancellationToken ct, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userId = authenticationState.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var userIdProperty = message.GetType().GetProperty("UserId");
        userIdProperty?.SetValue(message, userId);

        return await next(message, ct);
    }
}