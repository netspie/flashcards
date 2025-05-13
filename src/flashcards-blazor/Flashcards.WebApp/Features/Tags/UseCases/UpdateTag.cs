using Flashcards.WebApp.Infrastructure.RequestHandlerBehaviours;
using Flashcards.WebApp.Shared.Entities;
using Flashcards.WebApp.Shared.UseCases;
using Mediator;

namespace Flashcards.WebApp.Features.Tags;

public record UpdateTagCommand(
    string Id,
    string Name,
    string Color,
    int Order = int.MaxValue) : ICommand;

public class UpdateTagCommandHandler(
    //IRepositoryFactory _repositoryFactory,
    IReadOnlyRepository<Tag, TagId> _readRepository,
    IWriteOnlyRepository<Tag, TagId> _writeRepository) : CommandHandler<UpdateTagCommand>
{
    //private readonly IReadOnlyRepository<Tag, TagId> _readRepository = _repositoryFactory.Create<IReadOnlyRepository<Tag, TagId>>();
    //private readonly IWriteOnlyRepository<Tag, TagId> _writeRepository = _repositoryFactory.Create<IWriteOnlyRepository<Tag, TagId>>();

    public override async Task Handle(
        UpdateTagCommand cmd, CancellationToken ct) 
    {
        var e = await _readRepository.GetById(new TagId(cmd.Id));
        e = e with { Name = cmd.Name, Order = cmd.Order, Color = cmd.Color };

        //unitOfWork.Start(_writeRepository);
        //_writeRepository.AddTo(unitOfWork);

        await _writeRepository.UpdateOrderedItem(
            e,
            _readRepository,
            filterNeighbours: x => x.ProjectId == e.ProjectId && x.ParentTagId == e.ParentTagId);

        //unitOfWork.Save();
    }
}

//public override Task Handle(
//        UpdateTagCommand cmd, CancellationToken ct) =>
//        _readRepository
//            .GetById(new TagId(cmd.Id))
//            .MapAsync(e => e with { Name = cmd.Name, Order = cmd.Order, Color = cmd.Color })
//            .MapAsync(e =>
//                _writeRepository.UpdateOrderedItem(
//                    e,
//                    _readRepository,
//                    filterNeighbours: x => x.ProjectId == e.ProjectId && x.ParentTagId == e.ParentTagId));