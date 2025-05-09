using Flashcards.WebApp.Features.Projects;
using Mediator;
using System.Reflection.Metadata;

namespace Flashcards.WebApp.Shared.UseCases;
 
public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    async ValueTask<Unit> ICommandHandler<TCommand, Unit>.Handle(TCommand cmd, CancellationToken ct)
    {
        await Handle(cmd, ct);
        return new();
    }

    public abstract Task Handle(TCommand cmd, CancellationToken ct);
}