using Flashcards.WebApp.Shared.UseCases;
using Mediator;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Flashcards.WebApp.Infrastructure.MessageTransmuters;

public class BlazorServerMessageUserIdTransmuter<TRequest>(
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
