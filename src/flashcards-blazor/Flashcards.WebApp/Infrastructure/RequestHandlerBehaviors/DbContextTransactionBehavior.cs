using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.WebApp.Infrastructure.RequestHandlerBehaviors;

public class DbContextTransactionBehavior<TRequest, TResponse>(
    DbContext _context) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
{
    public async ValueTask<TResponse> Handle(
        TRequest message, CancellationToken ct, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var response = await next(message, ct);

            await transaction.CommitAsync();

            return response;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
