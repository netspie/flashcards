using Mediator;

namespace Flashcards.WebApp.Shared.UseCases;

public interface IMessageTransmuter<TMessage> where TMessage : notnull, IMessage
{
    ValueTask<TMessage> Handle(
        TMessage message,
        CancellationToken cancellationToken);
}